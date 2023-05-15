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
            get { return _classe; }
            set { _classe = value; }
        }

        public string Race
        {
            get { return _race; }
            set { _race = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Background
        {
            get { return _background; }
            set { _background = value; }
        }

        public string Alignement
        {
            get { return _alignement; }
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

    }
}
