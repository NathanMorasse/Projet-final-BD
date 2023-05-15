using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Security.Policy;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using ProjetFinale.CustomExceptions;

namespace ProjetFinale.Models
{
    public class Character
    {
        #region Attributs

        private int _id;
        private int _level;
        private int _health;
        private string _name;
        private DateTime _dateModif;
        private Characteristics _characteristics;
        private Statistics _statistics;
        private Inventory _inventory;
        private List<Ability> _abilities;

        #endregion

        #region Propriétés

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public DateTime DateModif
        {
            get { return _dateModif; }
            set { _dateModif = value; }
        }

        public Characteristics Characteristics
        {
            get { return _characteristics; }
            set { _characteristics = value; }
        }

        public Statistics Statistics
        {
            get { return _statistics; }
            set { _statistics = value; }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public List<Ability> Abilities
        {
            get
            {
                if (_abilities == null)
                {
                    return new List<Ability>();
                }
                return _abilities;
            }
            set { _abilities = value; }
        }


        #endregion

        #region Constructeur

        public Character(){}

        public Character(int id, int level, int health, string name)
        {
            this.Id = id;
            this.Level = level;
            this.Health = health;
            this.Name = name;
            Characteristics = new Characteristics();
            Statistics = new Statistics();
            Inventory = new Inventory();
            Abilities = new List<Ability>();
        }

        public Character(int id,string name, int level, DateTime dateModif)
        {
            this.Id = id;
            this.Name = name;
            this.Level = level;
            this.DateModif = dateModif;
        }

        public Character(string name, int health)
        {
            this.Name = name;
            this.Health = health;
        }
        #endregion

        #region Fonctions

        public void AddAbility(Ability Ajout)
        {
            foreach(Ability ability in Abilities)
            {
                if(ability == Ajout)
                {
                    throw new AbilityAlreadyInListException("L'habileté est déjà dans la liste.");
                }
            }
            Abilities.Add(Ajout);
        }


        public void DeleteAbility(Ability Delete)
        {
            bool exists = false;
            foreach (Ability ability in Abilities)
            {
                if (ability == Delete)
                {
                    exists = true;
                    break;
                }
            }


            if (exists)
            {
                Abilities.Remove(Delete);
            }
            else
            {
                throw new AbilityNotInListException("L'habileté n'existe pas dans la liste.");
            }
        }
        #endregion
    }
}
