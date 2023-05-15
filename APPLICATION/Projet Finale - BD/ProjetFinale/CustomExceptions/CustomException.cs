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

    public class AbilityNotInListException : Exception
    {
        public string errorName { get; }
        public AbilityNotInListException(string message):base(message) { }
        public AbilityNotInListException(string message, string errorName) : base(message)
        {
            this.errorName=errorName;
        }
    }

    public class CharacterALreadyExistsException :Exception
    {
        public string errorName { get; }
        public CharacterALreadyExistsException(string message) : base(message) { }
        public CharacterALreadyExistsException(string message, string errorName) : base(message)
        {
            this.errorName = errorName;
        }
    }

    public class CharacterDoesNotExistException : Exception
    {
        public string errorName { get; }
        public CharacterDoesNotExistException(string message) : base(message) { }
        public CharacterDoesNotExistException(string message, string errorName) : base(message)
        {
            this.errorName = errorName;
        }
    }

    public class ItemAlreadyInListException : Exception
    {
        public string errorName { get; }
        public ItemAlreadyInListException(string message) : base(message) { }
        public ItemAlreadyInListException(string message, string errorName) : base(message)
        {
            this.errorName = errorName;
        }
    }

    public class ItemNotInListException : Exception
    {
        public string errorName { get; }
        public ItemNotInListException(string message) : base(message) { }
        public ItemNotInListException(string message, string errorName) : base(message)
        {
            this.errorName = errorName;
        }
    }
}
