using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProjetFinale.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

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
        #endregion

        #region Constructeur
        public VMAbilities()
        {
            Abilities = new List<Ability>();
            AbilityList.LoadAbilities();
            Abilities = AbilityList.Abilities;
            DeleteAbility = new CommandeRelais(DeleteAbility_Execute, DeleteAbility_CanExecute);
            //CreateAbility = new CommandeRelais(Creat)
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
        #endregion
    }
}
