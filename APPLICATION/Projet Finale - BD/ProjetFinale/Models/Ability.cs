using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinale.Models
{
    public class Ability
    {
        #region Attributs
        private int _id;
        private int _distance;
        private string _rechargement;
        private string _name;
        private string _type;
        private string _diceToRoll;
        private string _descritpion;
        #endregion

        #region Propriétés
        
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Rechargement
        {
            get { return _rechargement; }
            set { _rechargement = value; }
        }

        public int Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string DiceToRoll
        {
            get { return _diceToRoll; }
            set { _diceToRoll = value; }
        }

        public string Description
        {
            get { return _descritpion; }
            set { _descritpion = value; }
        }
        #endregion

        #region Constructeur
        public Ability() { }
        public Ability(int id, string rechargement, string name, string type, string diceToRoll, string description, int distance)
        {
            Id = id;
            Rechargement = rechargement;
            Name = name;
            Type = type;
            DiceToRoll = diceToRoll;
            Description = description;
            Distance = distance;
        }

        public Ability(string rechargement, string name, string type, string diceToRoll, string description, int distance)
        {
            Rechargement = rechargement;
            Name = name;
            Type = type;
            DiceToRoll = diceToRoll;
            Description = description;
            Distance = distance;
        }

        #endregion
    }
}
