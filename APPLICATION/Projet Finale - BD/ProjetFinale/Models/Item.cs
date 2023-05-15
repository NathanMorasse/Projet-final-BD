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
        private int _idItems;
        private string _name;
        private string _diceToRoll;
        #endregion

        #region Propriétés
        public int IdItems
        {
            get { return _idItems; }
            set { _idItems = value; }
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
        #endregion


        #region Constructeur
        public Item() { }

        public Item(int idItems ,string name, string diceToRoll)
        {
            IdItems = idItems;
            Name = name;
            DiceToRoll = diceToRoll;
        }
        #endregion
    }
}
