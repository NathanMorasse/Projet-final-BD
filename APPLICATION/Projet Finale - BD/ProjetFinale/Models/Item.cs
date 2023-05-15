using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinale.Models
{
    public class Item
    {
        #region Attributs
        private int _id;
        private string _name;
        private string _diceToRoll;
        private string _description;
        private decimal _weight;
        #endregion

        #region Propriétés
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string DiceToRoll
        {
            get { return _diceToRoll; }
            set { _diceToRoll = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public decimal Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        #endregion


        #region Constructeur
        public Item() { }

        public Item(int id , string name, string diceToRoll, string description, decimal weight)
        {
            Id = id;
            Name = name;
            DiceToRoll = diceToRoll;
            Description = description;
            Weight = weight;
        }

        public Item(string name, string diceToRoll, string description, decimal weight)
        {
            Name = name;
            DiceToRoll = diceToRoll;
            Description = description;
            Weight = weight;
        }
        #endregion
    }
}
