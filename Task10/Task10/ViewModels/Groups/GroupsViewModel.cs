using A_Domain.Repo_interfaces;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Task10.Commands;
using Task10.Models;
using Task10.Specifications;
using Task10.State.Navigators;

namespace Task10.ViewModels
{
    public class GroupsViewModel : ViewModelBase
    {
        private readonly ObservableCollection<GroupViewModel> _groups;
        public IEnumerable<GroupViewModel> Groups => _groups;

        public readonly IUnitOfWork _unitOfWork;
        public readonly INavigator _navigator;

        public ICommand UpdateGroupCommand { get; }
        public ICommand DeleteGroupCommand { get; }
        public ICommand DeleteGroupByIdCommand { get; }
        public ICommand CreateGroupCommand { get; }
        public ICommand NavigateToStudentsViewCommand { get; }
        public ICommand CreateGroupDocCommand { get; }
        public ICommand CreatePDFDocCommand { get; }
        public ICommand ExportToCsvCommand { get; }
        public ICommand ImportFromCsvCommand { get; }

        public GroupsViewModel(IUnitOfWork unitOfWork, INavigator navigator)
        {
            _groups = new ObservableCollection<GroupViewModel>();
            _unitOfWork = unitOfWork;
            _navigator = navigator;

            CreateGroupCommand = new RelayCommand(param =>
            {
                _navigator.CurrentViewModel = new CreateGroupViewModel(_unitOfWork, _navigator);
            });

            DeleteGroupByIdCommand = new RelayCommand(param =>
            {
                _navigator.CurrentViewModel = new DeleteGroupViewModel(_unitOfWork, _navigator);
            });

            DeleteGroupCommand = new RelayCommand(param =>
            {
                if (param is GroupViewModel groupViewModel)
                {
                    bool ifAnyStudInCurrGroup = _unitOfWork.Students.GetAll().Where(x => x.GroupId == groupViewModel.Id).Any();

                    if (ifAnyStudInCurrGroup)
                    {
                        MessageBox.Show("You can't delete group with at least one student!");
                        return;
                    }


                    var group = _unitOfWork.Groups.GetAll().Include(t => t.TutorGroups).Where(x => x.Id == groupViewModel.Id).FirstOrDefault();

                    if (group == null)
                    {
                        MessageBox.Show("Group not found");
                        return;
                    }

                    try
                    {
                        _unitOfWork.TutorGroups.RemoveRange(group?.TutorGroups);

                        _unitOfWork.Groups.RemoveById(groupViewModel.Id);

                        _unitOfWork.Save();

                        MessageBox.Show($"Group has been successfully deleted!");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
                else
                {
                    MessageBox.Show("An unexpected error has occurred!");
                }

                _navigator.CurrentViewModel = LoadGroupsViewModel(_unitOfWork, _navigator);
            });

            UpdateGroupCommand = new RelayCommand(param =>
            {
                if (param is GroupViewModel group)
                {
                    _navigator.CurrentViewModel = new UpdateGroupViewModel(_unitOfWork, _navigator, group);
                }
            });

            NavigateToStudentsViewCommand = new RelayCommand(param =>
            {
                if (param is GroupViewModel group)
                {
                    var specification = new StudentsWithGroupSpecification((int)group.Id);
                    var studentsViewModel = StudentsViewModel.LoadStudentsViewModel(_unitOfWork, _navigator, specification);
                    _navigator.CurrentViewModel = studentsViewModel;
                }
            });

            CreateGroupDocCommand = new RelayCommand(param =>
            {
                if (param is GroupViewModel groupViewModel)
                {
                    try
                    {
                        GenerateGroupListDocument(groupViewModel);

                        MessageBox.Show("Word document was successfully created on your desktop!");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            });

            CreatePDFDocCommand = new RelayCommand(param =>
            {
                if (param is GroupViewModel groupViewModel)
                {
                    try
                    {
                        GenerateGroupListPDF(groupViewModel);

                        MessageBox.Show("PDF document was successfully created on your desktop!");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            });

            ExportToCsvCommand = new RelayCommand(param =>
            {
                if (param is GroupViewModel groupViewModel)
                {
                    try
                    {
                        ExportStudentsToCsv(groupViewModel);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            });

            ImportFromCsvCommand = new RelayCommand(param =>
            {
                if (param is GroupViewModel groupViewModel)
                {
                    try
                    {
                        ImportStudentsFromCsv(groupViewModel);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            });
        }

        public void GenerateGroupListDocument(GroupViewModel groupViewModel)
        {
            var course = _unitOfWork.Courses.GetAll().Where(x => x.Id == groupViewModel.CourseId).FirstOrDefault();

            string documentTitle = $"Group: {groupViewModel.Name} - Course: {course?.Name}";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"GroupStudents_{groupViewModel.Name}.docx");
            using (WordprocessingDocument document = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = document.AddMainDocumentPart();

                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                Paragraph titleParagraph = body.AppendChild(new Paragraph());
                Run titleRun = titleParagraph.AppendChild(new Run());
                titleRun.AppendChild(new Text(documentTitle));

                Paragraph studentListParagraph = body.AppendChild(new Paragraph());
                Run studentListRun = studentListParagraph.AppendChild(new Run());
                studentListRun.AppendChild(new Text("Student List:"));
                studentListRun.AppendChild(new Break());

                foreach (var student in _unitOfWork.Students.GetAll().Where(s => s.GroupId == groupViewModel.Id))
                {
                    studentListRun.AppendChild(new Text(student.FullName));
                    studentListRun.AppendChild(new Break());
                }
            }
        }

        public void GenerateGroupListPDF(GroupViewModel groupViewModel)
        {
            var course = _unitOfWork.Courses.GetAll().Where(x => x.Id == groupViewModel.CourseId).FirstOrDefault();

            string documentTitle = $"Group: {groupViewModel.Name} - Course: {course?.Name}";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"GroupStudents_{groupViewModel.Name}.pdf");

            using (PdfDocument document = new())
            {
                PdfPage page = document.AddPage();

                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont titleFont = new("Arial", 16, XFontStyle.Bold);
                XFont textFont = new("Arial", 12, XFontStyle.Regular);

                gfx.DrawString(documentTitle, titleFont, XBrushes.Black, new XRect(50, 50, page.Width - 100, 30), XStringFormats.TopCenter);

                int yOffset = 150;
                foreach (var student in _unitOfWork.Students.GetAll().Where(s => s.GroupId == groupViewModel.Id))
                {
                    gfx.DrawString(student.FullName, textFont, XBrushes.Black, new XRect(50, yOffset, page.Width - 100, 20), XStringFormats.TopLeft);
                    yOffset += 20;
                }

                document.Save(filePath);
            }
        }


        private void ExportStudentsToCsv(GroupViewModel groupViewModel)
        {
            var students = _unitOfWork.Students.GetAll().Where(s => s.GroupId == groupViewModel.Id).ToList();

            if (students.Count > 0)
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"GroupStudents_{groupViewModel.Name}.csv");

                using (StreamWriter writer = new(filePath))
                {
                    writer.WriteLine("ID,First Name,Last Name");

                    foreach (var student in students)
                    {
                        writer.WriteLine($"{student.Id},{student.FirstName},{student.LastName}");
                    }
                }

                MessageBox.Show("Students exported to CSV successfully!");
            }
            else
            {
                MessageBox.Show("No students found in the group.");
            }
        }

        private void ImportStudentsFromCsv(GroupViewModel groupViewModel)
        {
            var existingStudents = _unitOfWork.Students.GetAll().Where(s => s.GroupId == groupViewModel.Id).ToList();
            foreach (var student in existingStudents)
            {
                student.GroupId = null;
            }

            _unitOfWork.Save();

            OpenFileDialog openFileDialog = new()
            {
                Filter = "CSV Files (*.csv)|*.csv",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                using (StreamReader reader = new(filePath))
                {
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        if (values.Length >= 3 && int.TryParse(values[0], out int id))
                        {
                            var student = _unitOfWork.Students.GetAll().Where(x => x.Id == id).SingleOrDefault();

                            if (student != null)
                            {
                                student.FirstName = values[1];
                                student.LastName = values[2];
                                student.GroupId = groupViewModel.Id;
                            }
                        }
                    }
                }

                _unitOfWork.Save();

                MessageBox.Show("Students imported from CSV successfully!");
            }
            else
            {
                MessageBox.Show("No CSV file selected.");
            }
        }

        public static GroupsViewModel LoadGroupsViewModel(IUnitOfWork unitOfWork, INavigator navigator, ISpecification<Group> specification = null)
        {
            GroupsViewModel groupsViewModel = new(unitOfWork, navigator);
            groupsViewModel.LoadGroupsFromDatabase(specification);

            return groupsViewModel;
        }

        private void LoadGroupsFromDatabase(ISpecification<Group> specification = null)
        {
            IEnumerable<Group> groupsFromDb = _unitOfWork.Groups.GetAll();

            if (specification != null)
            {
                groupsFromDb = groupsFromDb.Where(specification.IsSatisfiedBy);
            }

            var groupsList = groupsFromDb.ToList();

            foreach (var group in groupsList)
            {
                var groupViewModel = new GroupViewModel(group);
                _groups.Add(groupViewModel);
            }
        }
    }
}
