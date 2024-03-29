﻿using System.Collections.Generic;

namespace Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
