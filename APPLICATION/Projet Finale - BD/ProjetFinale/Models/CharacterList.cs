using ProjetFinale.CustomExceptions;
using ProjetFinale.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ProjetFinale.Models
{
    public static class CharacterList
    {
        #region Attributs
        private static List<Character> _characters;
        private static List<Character> _highestLevelCharacters;
        private static List<Character> _lastUpdatedCharacters;
        #endregion

        #region Propriétés
        public static List<Character> Characters
        {
            get { return _characters; }
            set { _characters = value; }
        }

        public static List<Character> LastUpdatedCharacters
        {
            get { return _lastUpdatedCharacters; }
            set { _lastUpdatedCharacters = value; }
        }

        public static List<Character> HighestLevelCharacters
        {
            get { return _highestLevelCharacters; }
            set { _highestLevelCharacters = value; }
        }
        #endregion

        #region Fonctions
        public static void LoadCharacters()
        {
            DAL dal = new DAL();
            Characters = dal.CharacterFact.GetAllCharacters();
            HighestLevelCharacters = dal.CharacterFact.GetHighestLvlCharacters();
            LastUpdatedCharacters = dal.CharacterFact.GetLastUpdatedCharacters();
        }

        public static void AddCharacter(Character Ajout)
        {
            foreach(Character character in Characters)
            {
                if(character.Name == Ajout.Name)
                {
                    throw new CharacterALreadyExistsException("Ce personnage existe déjà");
                }

                Characters.Add(character);
            }
        }

        public static void UpdateCharacter(Character Modif)
        {
            int index = 0;
            foreach(Character character in Characters)
            {

                if(character.Id == Modif.Id)
                {
                    break;
                }
                index++;
            }

            Characters[index] = Modif;
        }

        public static void DeleteCharacter(Character Delete)
        {
            bool exists = false;

            foreach(Character character in Characters)
            {
                if(character == Delete)
                {
                    exists = true;
                    break;
                }
            }

            if (exists)
            {
                Characters.Remove(Delete);
            }
            else
            {
                throw new CharacterDoesNotExistException("Le personnage n'existe pas dans la liste des personnages.");
            }
        }
        #endregion
    }
}
