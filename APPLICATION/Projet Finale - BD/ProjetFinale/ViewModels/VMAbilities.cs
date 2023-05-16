using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProjetFinale.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Markup;

namespace ProjetFinale.ViewModels
{
    public class VMAbilities : INotifyPropertyChanged
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
        private List<Ability> _abilities;
        private Ability _abilitySelection;
        private string _name;
        private string _periodeRechargement;
        private string _typeHabilete;
        private string _diceToRoll;
        private string _description;
        private int _distance;

        #endregion

        #region Propriétés
        public List<Ability> Abilities
        {
            get
            {
                if (_abilities == null)
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

        public Ability AbilitySelection
        {
            get { return _abilitySelection; }
            set
            {
                _abilitySelection = value;
                ChangeValue("AbilitySelection");
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

        public string PeriodeRechargement
        {
            get { return _periodeRechargement; }
            set
            {
                _periodeRechargement = value;
                ChangeValue("PeriodeRechargement");
            }
        }

        public string TypeHabilete
        {
            get { return _typeHabilete; }
            set 
            {
                _typeHabilete = value;
                ChangeValue("TypeHabilete");
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

        public string Description
        {
            get { return _diceToRoll; }
            set 
            {
                _diceToRoll = value; 
                ChangeValue("Description");
            }
        }

        public int Distance
        {
            get { return _distance; }
            set
            {
                _distance = value;
                ChangeValue("Distance");
            }
        }
        #endregion

        #region Constructeur
        public VMAbilities()
        {
            Abilities = new List<Ability>();
            AbilityList.LoadAbilities();
            Abilities = AbilityList.Abilities;
            DeleteAbility = new CommandeRelais(DeleteAbility_Execute, DeleteAbility_CanExecute);
            CreateAbility = new CommandeRelais(CreateAbility_Execute, CreateAbility_CanExecute);
        }
        #endregion

        #region Commandes
        private ICommand _deleteAbility;
        public ICommand DeleteAbility
        {
            get { return _deleteAbility; }
            set { _deleteAbility = value; }
        }

        private ICommand _createAbility;
        public ICommand CreateAbility
        {
            get { return _createAbility; }
            set { _createAbility = value; }
        }

        private void DeleteAbility_Execute(object parameter)
        {
            if (VerifDeleteAbility())
            {
                try
                {
                    AbilityList.DeleteAbility(AbilitySelection);
                    Abilities = AbilityList.Abilities;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CreateAbility_Execute(object parameter)
        {
            if(VerifCreateAbility())
            {
                try
                {
                    AbilityList.AddAbility(new(PeriodeRechargement, Name, TypeHabilete, DiceToRoll, Description, Distance));
                    Abilities = AbilityList.Abilities;
                    AbilitySelection = Abilities[Abilities.Count - 1];
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool CreateAbility_CanExecute(object parameter)
        {
            return true;    
        }

        private bool DeleteAbility_CanExecute(object parameter)
        {
            return true;
        }
        #endregion

        #region Fonctions
        private bool VerifDeleteAbility()
        {
            if(AbilitySelection != null)
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

        private bool VerifCreateAbility()
        {
            if(Name != null && Name !=  string.Empty && PeriodeRechargement != null && PeriodeRechargement != string.Empty
                && TypeHabilete != null && TypeHabilete != string.Empty && DiceToRoll != null && DiceToRoll != string.Empty
                && Description != null && Description != string.Empty && Distance > 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
