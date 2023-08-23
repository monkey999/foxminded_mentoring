using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Identities
{
    public class Accountant : User
    {
        public Accountant(Guid id, string firtName, string lastName) : base(id, firtName, lastName)
        {
        }
    }
}
