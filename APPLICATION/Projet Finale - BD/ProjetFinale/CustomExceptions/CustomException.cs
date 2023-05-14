using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinale.CustomExceptions
{
    public class AbilityAlreadyInListException : Exception
    {
        public string errorName { get; }
        public AbilityAlreadyInListException(string message):base(message) { }
        public AbilityAlreadyInListException(string message, string errorName) : base(message)
        {
            this.errorName = errorName;
        }
    }
}
