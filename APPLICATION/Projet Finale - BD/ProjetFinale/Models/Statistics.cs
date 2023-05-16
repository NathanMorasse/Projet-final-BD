using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinale.Models
{
    public class Statistics
    {
        #region Attributs
        private int _id;
        private int _strength = 1;
        private int _dexterity = 1;
        private int _constitution = 1;
        private int _intelligence = 1;
        private int _wisdom = 1;
        private int _charisma = 1;
        private int _armor = 1;
        #endregion

        #region Propriétés
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Strength
        {
            get { return _strength; }
            set { _strength = value; }
        }

        public int Dexterity
        {
            get { return _dexterity; }
            set { _dexterity = value; }
        }

        public int Constitution
        {
            get { return _constitution; }
            set { _constitution = value;}
        }

        public int Intelligence
        {
            get { return _intelligence; }
            set { _intelligence = value; }
        }

        public int Wisdom
        {
            get { return _wisdom; }
            set { _wisdom = value;}
        }

        public int Charisma
        {
            get { return _charisma; }
            set { _charisma = value; }
        }

        public int Armor
        {
            get { return _armor; }
            set { _armor = value; }
        }
        #endregion

        #region Constructeur
        public Statistics() { }

        public Statistics(int id, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int armor)
        {
            Id = id;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
            Armor = armor;
        }


        #endregion
    }
}
