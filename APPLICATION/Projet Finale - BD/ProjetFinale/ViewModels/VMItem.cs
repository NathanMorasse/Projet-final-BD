using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProjetFinale.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace ProjetFinale.ViewModels
{
    public class VMItem:INotifyPropertyChanged
    {
        #region Notify Property Changed
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void ChangeValue(string nomPropriete)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
            }
        }
        #endregion

        #region Attributs 
        private List<Item> _items;
        private Item _itemSelection;
        private string _name;
        private string _description;
        private string _diceToRoll;
        private decimal _weight;
        #endregion

        #region Propriétés
        public bool IsItemSelected
        {
            get 
            {
                if (ItemSelection == null)
                {
                    return false;
                }
                return true;
            }
        }

        public List<Item> Items
        {
            get
            {
                if (_items == null)
                {
                    return new List<Item>();
                }
                return new List<Item>(_items);
            }
            set
            {
                _items = value;
                ChangeValue("Items");
            }
        }

        public Item ItemSelection
        {
            get
            {
                return _itemSelection;
            }

            set
            {
                _itemSelection = value;
                ChangeValue("ItemSelection");
                ChangeValue("IsItemSelected");
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                ChangeValue("Name");
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                ChangeValue("Description");
            }
        }

        public string DiceToRoll
        {
            get { return _diceToRoll; }
            set
            {
                _diceToRoll = value;
                ChangeValue("DiceToRoll");
            }
        }

        public decimal Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                ChangeValue("Weight");
            }
        }
        #endregion

        #region Constructeur
        public VMItem()
        {
            this.Items = new List<Item>();
            ItemList.LoadItems();
            Items = ItemList.Items;
            DeleteItem = new CommandeRelais(DeleteItem_Execute, DeletedItem_CanExecute);
            CreateItem = new CommandeRelais(CreateItem_Execute, CreateItem_CanExecute);
        }
        #endregion

        #region Commandes
        private ICommand _deleteItem;
        public ICommand DeleteItem
        {
            get { return _deleteItem; }
            set { _deleteItem = value; }
        }

        private ICommand _createItem;
        public ICommand CreateItem
        {
            get { return _createItem; }
            set { _createItem = value; }
        }

        private void DeleteItem_Execute(object parameter)
        {
            if (VerifDeleteItem())
            {
                try
                {
                    ItemList.DeleteItem(ItemSelection);
                    Items = ItemList.Items;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CreateItem_Execute(object parameter)
        {
            if(VerifCreateItem())
            {
                try
                {
                    ItemList.AddItem(new(Name, DiceToRoll, Description, Weight));
                    Items = ItemList.Items;
                    ItemSelection = Items[Items.Count - 1];
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }



        private bool DeletedItem_CanExecute(object parameter)
        {
            return true;
        }
        private bool CreateItem_CanExecute(object parameter)
        {
            return true;
        }
        #endregion

        #region Fonctions
        private bool VerifDeleteItem()
        {
            if(ItemSelection != null)
            {
                return true;
            }
            return false;
        }

        private bool VerifCreateItem()
        {
            if(Name != null && Name !=  string.Empty && Description != null && Description != string.Empty && DiceToRoll != null 
                && DiceToRoll != string.Empty && DiceToRoll.Length < 6 && Weight >= 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
