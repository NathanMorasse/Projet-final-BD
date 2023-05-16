using Accessibility;
using Org.BouncyCastle.Asn1.Mozilla;
using Org.BouncyCastle.Crypto.Agreement;
using ProjetFinale.DataAccessLayer;
using ProjetFinale.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjetFinale.ViewModels
{
    public class VMPersonnage : INotifyPropertyChanged
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

        #region Attribut
        private List<Character> _characters;
        private List<Item> _items;
        private List<Ability> _abilities;
        private List<Item> _characterInventory;
        private List<Ability> _characterAbilities;
        private Character _characterSelection;
        private Item _itemSelection;
        private Item _inventorySelectedItem;
        private Ability _abilitySelection;
        private Ability _characterSelectedAbility;
        private string _name;
        private string _race;
        private string _classe;
        private string _description;
        private string _background;
        private string _alignement;
        private int _health;
        #endregion

        #region Propriétés
        public List<Character> Characters
        {
            get
            {
                if (_characters == null)
                {
                    return new List<Character>();
                }
                return new List<Character>(_characters);
            }
            set
            {
                _characters = value;
                ChangeValue("Characters");
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

        public List<Ability> Abilities
        {
            get
            {
                if(_abilities == null)
                {
                    return new List<Ability>();
                }
                return new List<Ability>(_abilities);
            }
            set
            {
                _abilities = value;
                ChangeValue("Abilities");
            }
        }

        public List<Item> CharacterInventory
        {
            get
            {
                if(CharacterSelection.Inventory == null)
                {
                    return new List<Item>();
                }
                return new List<Item>(CharacterSelection.Inventory);
            }
            set
            {
                _characterInventory = CharacterSelection.Inventory;
                ChangeValue("CharacterInventory");
            }
        }

        public List<Ability> CharacterAbilities
        {
            get
            {
                if (CharacterSelection.Abilities == null)
                {
                    return new List<Ability>();
                }
                return new List<Ability>(CharacterSelection.Abilities);
            }
            set
            {
                _characterAbilities = CharacterSelection.Abilities;
                ChangeValue("CharacterAbilities");
            }
        }

        public Character CharacterSelection
        {
            get
            {
                return _characterSelection;
            }
            set
            {
                _characterSelection = value;
                ChangeValue("CharacterSelection");
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
            }
        }

        public Item InventorySelectedItem
        {
            get
            {
                return _inventorySelectedItem;
            }
            set
            {
                _inventorySelectedItem = value;
                ChangeValue("InventorySelectedItem");
            }
        }

        public Ability AbilitySelection
        {
            get
            {
                return _abilitySelection;
            }
            set
            {
                _abilitySelection = value;
                ChangeValue("AbilitySelection");
            }
        }

        public Ability CharacterSelectedAbility
        {
            get
            {
                return _characterSelectedAbility;
            }
            set
            {
                _characterSelectedAbility = value;
                ChangeValue("CharacterSelectedAbility");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                ChangeValue("Name");
            }
        }

        public string Race
        {
            get { return _race; }
            set
            {
                _race = value;
                ChangeValue("Race");
            }
        }

        public string Classe
        {
            get { return _classe; }
            set
            {
                _classe = value;
                ChangeValue("Classe");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                ChangeValue("Description");
            }
        }

        public string Background
        {
            get { return _background; }
            set
            {
                _background = value;
                ChangeValue("Background");
            }
        }

        public string Alignement
        {
            get { return _alignement; }
            set
            {
                _alignement = value;
                ChangeValue("Alignement");
            }
        }

        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;
                ChangeValue("Health");
            }
        }
        #endregion

        #region Constructeur
        public VMPersonnage()
        {
            CharacterList.LoadCharacters();
            Characters = CharacterList.Characters;
            ItemList.LoadItems();
            Items = ItemList.Items;
            AbilityList.LoadAbilities();
            Abilities = AbilityList.Abilities;
            CreateCharacter = new CommandeRelais(CreateCharacter_Execute, CreateCharacter_CanExecute);
            DeleteCharacter = new CommandeRelais(DeleteCharacter_Execute, DeleteCharacter_CanExecute);
            ModifCharacter = new CommandeRelais(ModifCharacter_Execute, ModifCharacter_CanExecute);
            AjoutItemInventory = new CommandeRelais(AjoutItemInventory_Execute, AjoutItemInventory_CanExecute);
            DeleteItemInventory = new CommandeRelais(DeleteItemInventory_Execute, DeleteItemInventory_CanExecute);
            AddAbilityCharacter = new CommandeRelais(AddAbilityCharacter_Execute, AddAbilityCharacter_CanExecute);
            DeleteAbilityCharacter = new CommandeRelais(DeleteAbilityCharacter_Execute, DeleteAbilityCharacter_CanExecute);
        }
        #endregion

        #region Commandes
        private ICommand _createCharacter;
        public ICommand CreateCharacter
        {
            get { return _createCharacter; }
            set { _createCharacter = value; }
        }

        private ICommand _deleteCharacter;
        public ICommand DeleteCharacter
        {
            get { return _deleteCharacter; }
            set { _deleteCharacter = value; }
        }

        private ICommand _modifCharacter;
        public ICommand ModifCharacter
        {
            get { return _modifCharacter; }
            set { _modifCharacter = value; }
        }

        private ICommand _ajoutItemInventory;
        public ICommand AjoutItemInventory
        {
            get { return _ajoutItemInventory;}
            set { _ajoutItemInventory = value;}
        }

        private ICommand _deleteItemInventory;
        public ICommand DeleteItemInventory
        {
            get { return _deleteItemInventory; }
            set { _deleteItemInventory = value; }
        }

        private ICommand _addAbilityCharacter;
        public ICommand AddAbilityCharacter
        {
            get { return _addAbilityCharacter; }
            set { _addAbilityCharacter = value; }
        }

        private ICommand _deleteAbilityCharacter;
        public ICommand DeleteAbilityCharacter
        {
            get { return _deleteAbilityCharacter; }
            set { _deleteAbilityCharacter = value;
            }
        }
        private void AddAbilityCharacter_Execute(object parameter)
        {
            if (VerifAddAbilityCharacter())
            {
                try
                {
                    CharacterSelection.AddAbility(AbilitySelection, CharacterSelection);
                    CharacterAbilities = CharacterSelection.Abilities;
                    ChangeValue("CharacterAbilities");
                    ChangeValue("CharacterSelection");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DeleteAbilityCharacter_Execute(object parameter)
        {
            if (VerifDeleteAbilityCharacter())
            {
                try
                {
                    CharacterSelection.DeleteAbility(CharacterSelectedAbility);
                    CharacterAbilities = CharacterSelection.Abilities;
                    ChangeValue("CharacterAbilities");
                    ChangeValue("CharacterSelection");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CreateCharacter_Execute(object Parameter)
        {
            if (VerifCreateCharacter())
            {
                try
                {
                    Character newCharacter = new Character(Name, Health);
                    newCharacter.Characteristics = new(Classe, Race, Description, Background, Alignement);
                    CharacterList.AddCharacter(newCharacter);
                    Characters = CharacterList.Characters;
                    CharacterSelection = Characters[Characters.Count - 1];
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DeleteCharacter_Execute(object Parameter)
        {
            if (VerifDeleteCharacter())
            {
                try
                {
                    CharacterList.DeleteCharacter(CharacterSelection);
                    Characters = CharacterList.Characters;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ModifCharacter_Execute(object Parameter)
        {
            if (VerifModifCharacter())
            {
                try
                {
                    CharacterList.UpdateCharacter(CharacterSelection);
                    Characters = CharacterList.Characters;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void AjoutItemInventory_Execute(object parameter)
        {
            if (VerifAjoutItemToInventory())
            {
                try
                {

                    CharacterSelection.AddItem(ItemSelection, CharacterSelection.Id);
                    CharacterInventory = CharacterSelection.Inventory;
                    ChangeValue("CharacterInventory");
                    ChangeValue("CharacterSelection");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DeleteItemInventory_Execute(object parameter)
        {
            if (VerifDeleteItemFromInventory())
            {
                try
                {
                    CharacterSelection.DeleteItem(InventorySelectedItem, CharacterSelection.Id);
                    CharacterInventory = CharacterSelection.Inventory;
                    ChangeValue("CharacterInventory");
                    ChangeValue("CharacterSelection");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool DeleteAbilityCharacter_CanExecute(object paramter)
        {
            return true;
        }

        private bool AjoutItemInventory_CanExecute(object parameter)
        {
            return true;
        }

        private bool AddAbilityCharacter_CanExecute(object parameter)
        {
            return true;
        }

        private bool CreateCharacter_CanExecute(object Parameter)
        {
            return true;
        }

        private bool DeleteCharacter_CanExecute(object Parameter)
        {
            return true;
        }

        private bool ModifCharacter_CanExecute(object Parameter)
        {
            return true;
        }

        private bool DeleteItemInventory_CanExecute(object parameter)
        {
            return true;
        }
        #endregion

        #region Fonctions
        private bool VerifCreateCharacter()
        {
            if (Name != null && Name != string.Empty && Race != null && Race != string.Empty
                && Classe != null && Classe != string.Empty && Alignement != null && Alignement != string.Empty
                && Health >= 0)
            {
                return true;
            }

            return false;
        }

        private bool VerifDeleteCharacter()
        {
            if (CharacterSelection != null)
            {
                return true;
            }
            return false;
        }

        private bool VerifModifCharacter()
        {
            if(CharacterSelection.Name != null && CharacterSelection.Name !=  string.Empty
                && CharacterSelection.Level >= 0 && CharacterSelection.Health >= 0 
                && CharacterSelection.Characteristics.Classe != null && CharacterSelection.Characteristics.Classe != string.Empty
                && CharacterSelection.Characteristics.Alignement != null && CharacterSelection.Characteristics.Alignement != string.Empty
                && CharacterSelection.Characteristics.Race != null && CharacterSelection.Characteristics.Race != string.Empty
                && CharacterSelection.Statistics.Charisma > 0 && CharacterSelection.Statistics.Wisdom > 0
                && CharacterSelection.Statistics.Intelligence > 0 && CharacterSelection.Statistics.Armor > 0
                && CharacterSelection.Statistics.Constitution > 0 && CharacterSelection.Statistics.Dexterity > 0)
            {
                return true;
            }

            return false;
        }

        private bool VerifAjoutItemToInventory()
        {
            if(CharacterSelection != null && ItemSelection != null)
            {
                return true;
            }

            return false;
        }

        private bool VerifDeleteItemFromInventory()
        {
            if(CharacterSelection != null && InventorySelectedItem != null)
            {
                return true;
            }
            return false;
        }

        private bool VerifAddAbilityCharacter()
        {
            if (AbilitySelection != null)
            {
                return true;
            }
            return false;
        }

        private bool VerifDeleteAbilityCharacter()
        {
            if(CharacterSelectedAbility != null)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
