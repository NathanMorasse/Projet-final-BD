using ProjetFinale.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinale.ViewModels
{
    public class VMAcceuil:INotifyPropertyChanged
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
        private List<Character> _lastUpdatedCharacters;
        private List<Character> _highestLevelCharacters;
        #endregion

        #region Propriétés
        public List<Character> LastUpdatedCharacters
        {
            get 
            {
                if(_lastUpdatedCharacters == null)
                {
                    return new List<Character>();
                }
                return _lastUpdatedCharacters; 
            }
            set
            {
                _lastUpdatedCharacters = value;
                ChangeValue("LastUpdatedCharacters");
            }
        }

        public List<Character> HighestLevelCharacters
        {
            get
            {
                if(_highestLevelCharacters == null)
                {
                    return new List<Character>();
                }
                return _highestLevelCharacters;
            }
            set
            {
                _highestLevelCharacters = value;
                ChangeValue("HighestLevelCharacters");
            }
        }
        #endregion

        #region Constructeur
        public VMAcceuil()
        {
            CharacterList.LoadCharacters();
            HighestLevelCharacters = CharacterList.HighestLevelCharacters;
            LastUpdatedCharacters = CharacterList.LastUpdatedCharacters;
        }
        #endregion

        #region Fonctions

        #endregion
    }
}
