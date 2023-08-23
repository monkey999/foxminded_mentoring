using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum DebtAccountType
    {
        /// <summary>
        /// If DebtAccount marked as IDebtGiver, then amount property value is 
        /// a value that was decreased from my own money accounts and they were given to someone and its pending to be returned.
        /// </summary>
        IDebtGiver,
        /// <summary>
        /// If DebtAccount marked as IDebtTaker, then amount property value is 
        /// a value that was decreased from my own money accounts and they were given to someone and its pending to be returned.
        /// </summary>
        IDebtTaker
    }
}
