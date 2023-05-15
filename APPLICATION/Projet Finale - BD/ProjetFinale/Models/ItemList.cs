using ProjetFinale.CustomExceptions;
using System;
using System.Collections.Generic;
using ProjetFinale.DataAccessLayer;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinale.Models
{
    public static class ItemList
    {
        #region Attributs
        private static List<Item> _items;
        #endregion

        #region Propriétés
        public static List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        #endregion

        #region Fonctions

        public static void LoadItems()
        {
            Items = new DAL().ItemFact.GetAllItems();
        }
        public static void AddItem(Item Ajout)
        {
            foreach (Item item in Items)
            {
                if (item.Name == Ajout.Name)
                {
                    throw new ItemAlreadyInListException("L'item existe déjà dans la liste des habiletés");
                }
            }
            Items.Add(Ajout);
            new DAL().ItemFact.AddItem(Ajout);
        }

        public static void DeleteItem(Item Delete)
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
                new DAL().ItemFact.DeleteItem(Delete);
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
