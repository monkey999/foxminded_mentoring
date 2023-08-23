using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTO_Contracts.Requests.Create
{
    public class CreateCategoryReqDTO
    {
        public string CategoryName { get; set; }
        public string CategoryType { get; set; }
    }
}
