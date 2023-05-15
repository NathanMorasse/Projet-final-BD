using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinale.Models
{
    public class Characteristics
    {
        #region Attributs
        private int _id;
        private string _classe;
        private string _race;
        private string _description;
        private string _background;
        private string _alignement;
        #endregion

        #region Propriétés
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Classe
        {
            get 
            {
                if(_classe == null || _classe == string.Empty)
                {
                    return _classe = string.Empty;
                }
                return _classe; 
            }
            set { _classe = value; }
        }

        public string Race
        {
            get 
            {
                if(_race == null || _race == string.Empty)
                {
                    return string.Empty;
                }
                return _race; 
            }
            set { _race = value; }
        }

        public string Description
        {
            get 
            {
                if(_description == null || _description == string.Empty)
                {
                    return string.Empty;
                }
                return _description; 
            }
            set { _description = value; }
        }

        public string Background
        {
            get 
            {
                if (_background == null || _background == string.Empty)
                {
                    return string.Empty;
                }
               return _background;
            }
            set { _background = value; }
        }

        public string Alignement
        {
            get 
            {
                if (_alignement == null || _alignement == string.Empty)
                {
                    return string.Empty;
                }
               return _alignement;
            }
            set { _alignement = value; }
        }
        #endregion


        public Characteristics() { }

        public Characteristics(int id,string classe, string race, string description, string background, string alignement)
        {
            Id = id;
            Classe = classe;
            Race = race;
            Description = description;
            Background = background;
            Alignement = alignement;
        }

        public Characteristics(string classe, string race, string description, string background, string alignement)
        {
            Classe = classe;
            Race = race;
            Description = description;
            Background = background;
            Alignement = alignement;
        }
    }
}
