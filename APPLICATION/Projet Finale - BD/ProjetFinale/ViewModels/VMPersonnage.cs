using Accessibility;
using Org.BouncyCastle.Asn1.Mozilla;
using Org.BouncyCastle.Crypto.Agreement;
using ProjetFinale.DataAccessLayer;
using ProjetFinale.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private Character _characterSelection;
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
                return _characters;
            }
            set
            {
                _characters = value;
                ChangeValue("Characters");
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
            CreateCharacter = new CommandeRelais(CreateCharacter_Execute, CreateCharacter_CanExecute);
            DeleteCharacter = new CommandeRelais(DeleteCharacter_Execute, DeleteCharacter_CanExecute);
            ModifCharacter = new CommandeRelais(ModifCharacter_Execute, ModifCharacter_CanExecute);
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
        private void CreateCharacter_Execute(object Parameter)
        {
            if (VerifCreateCharacter())
            {
                Character newCharacter = new Character(Name, Health);
                newCharacter.Characteristics = new(Classe, Race, Description, Background, Alignement);
                CharacterList.AddCharacter(newCharacter);
            }
        }

        private void DeleteCharacter_Execute(object Parameter)
        {
            if (VerifDeleteCharacter())
            {
                CharacterList.DeleteCharacter(CharacterSelection);
            }
        }

        private void ModifCharacter_Execute(object Parameter)
        {
            if (VerifModifCharacter())
            {
                CharacterList.UpdateCharacter(CharacterSelection);
            }
        }

        private bool CreateCharacter_CanExecute(object Parameter)
        {
            return true;
        }

        private bool DeleteCharacter_CanExecute(object Parameter)
        {
            return true;
        }

        private bool ModifCharacter_CanExecute(Object Parameter)
        {
            return true;
        }
        #endregion

        #region Fonctions
        private bool VerifCreateCharacter()
        {
            if (Name != null && Name != string.Empty && Race != null && Race != string.Empty
                && Classe != null && Classe != string.Empty && Alignement != null && Alignement != string.Empty
                && Health < 0)
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
                && CharacterSelection.Level > 0 && CharacterSelection.Health >= 0 
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
        #endregion
    }
}
