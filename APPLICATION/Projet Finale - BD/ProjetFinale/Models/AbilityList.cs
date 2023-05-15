using System;
using System.Collections.Generic;
using ProjetFinale.CustomExceptions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinale.Models
{
    public static class AbilityList
    {
        #region Attributs
        private static List<Ability> _abilities;
        #endregion

        #region Propriétés
        public static List<Ability> Abilities
        {
            get { return _abilities; }
            set { _abilities = value; }
        }
        #endregion

        #region Fonctions
        public static void LoadAbilities()
        {
            throw new NotImplementedException();
        }

        public static void AddAbility(Ability Ajout)
        {
            foreach(Ability ability in Abilities)
            {
                if(ability.Name == Ajout.Name)
                {
                    throw new AbilityAlreadyInListException("L'habileté existe déjà dans la liste des habiletés");
                }
            }

            Abilities.Add(Ajout);
        }

        public static void DeleteAbility(Ability Delete)
        {
            bool exists = false;
            foreach (Ability ability in Abilities)
            {
                if (ability == Delete)
                {
                    exists = true;
                    break;
                }
            }


            if (exists)
            {
                Abilities.Remove(Delete);
            }
            else
            {
                throw new AbilityNotInListException("L'habileté n'existe pas dans la liste.");
            }
        }
        #endregion
    }
}
