using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Security.Policy;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using ProjetFinale.CustomExceptions;
using ProjetFinale.DataAccessLayer;

namespace ProjetFinale.Models
{
    public class Character
    {
        #region Attributs

        private int _id;
        private int _level = 1;
        private int _health;
        private string _name;
        private DateTime _dateModif;
        private Characteristics _characteristics;
        private Statistics _statistics;
        private List<Item> _inventory;
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

        public List<Item> Inventory
        {
            get 
            {
                if( _inventory == null)
                {
                    _inventory = new List<Item>();
                    return _inventory;
                }
                return _inventory;
            }
            set { _inventory = value; }
        }

        public List<Ability> Abilities
        {
            get
            {
                if (_abilities == null)
                {
                    _abilities = new List<Ability>();
                    return _abilities;
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
            Inventory = new List<Item>();
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

        public void AddAbility(Ability Ajout, Character Character)
        {
            foreach(Ability ability in Abilities)
            {
                if(ability == Ajout)
                {
                    throw new AbilityAlreadyInListException("L'habileté est déjà dans la liste.");
                }
            }
            Abilities.Add(Ajout);
            new DAL().AbilityFact.AddAbilityToCharacter(this.Id, Ajout.Id);
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
                new DAL().AbilityFact.RemoveAbilityFromCharacter(this.Id, Delete.Id);
            }
            else
            {
                throw new AbilityNotInListException("L'habileté n'existe pas dans la liste.");
            }
        }

        public void AddItem(Item Ajout, int IdCharacter)
        {
            foreach (Item itme in Inventory)
            {
                if (itme.Name == Ajout.Name)
                {
                    throw new AbilityAlreadyInListException("L'item est déjà dans l'inventaire.");
                }
            }
            Inventory.Add(Ajout);
            new DAL().ItemFact.AddItemToCharacterInventory(Ajout.Id, IdCharacter, Ajout.Quantity);
        }

        public void DeleteItem(Item Delete, int idCharacter)
        {
            bool exists = false;
            foreach (Item item in Inventory)
            {
                if (item.Name == Delete.Name)
                {
                    exists = true;
                    break;
                }
            }


            if (exists)
            {
                Inventory.Remove(Delete);
                new DAL().ItemFact.RemoveItemFromCharacterInventory(Delete.Id, idCharacter);
            }
            else
            {
                throw new AbilityNotInListException("L'item n'existe pas dans l'inventaire.");
            }
        }
        #endregion
    }
}
