using ProjetFinale.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinale.Models
{
    public class Inventory
    {
        #region Attributs
        private List<Item> _items;
        private int _quantite;
        #endregion

        #region Propriétés
        public List<Item> Items
        {
            get 
            {
                if(Items == null)
                {
                    return new List<Item>();
                }
                return _items; 
            }
            set { _items = value; }
        }

        public int Quantite
        {
            get { return _quantite; }
            set { _quantite = value; }
        }
        #endregion

        #region Constructeur
        public Inventory() { }
        public Inventory(int quantitie)
        {
            Quantite = quantitie;
            Items = new List<Item>();
        }
        #endregion

        #region Fonctions
        public void AddItem(Item Ajout)
        {
            foreach (Item item in Items)
            {
                if (item.Name == Ajout.Name)
                {
                    throw new ItemAlreadyInListException("L'item existe déjà dans la liste des habiletés")
                }
            }

            Items.Add(Ajout);
        }

        public void DeleteItem(Item Delete)
        {
            bool exists = false;
            foreach (Item item in Items)
            {
                if (item == Delete)
                {
                    exists = true;
                    break;
                }
            }


            if (exists)
            {
                Items.Remove(Delete);
            }
            else
            {
                throw new ItemNotInListException("L'item n'existe pas dans la liste.");
            }
        }
        #endregion
    }
}
