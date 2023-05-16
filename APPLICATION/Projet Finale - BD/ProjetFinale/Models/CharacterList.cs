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
            foreach (Character character in Characters)
            {
                character.Characteristics = new DAL().CharacteristicsFact.GetCharacteristicsByCharacterId(character.Id);
                character.Statistics = new DAL().StatisticsFact.GetStatisticsByCharacterId(character.Id);
                character.Abilities = new DAL().AbilityFact.GetAbilityByCharacterId(character.Id);
                character.Inventory = new DAL().ItemFact.GetInventoryByCharacterId(character.Id);
            }
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
            }
            Characters.Add(Ajout);
            new DAL().CharacterFact.AddCharacter(Ajout);
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
            new DAL().CharacterFact.UpdateCharacter(Modif);
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

            new DAL().CharacterFact.DeleteCharacter(Delete);
        }
        #endregion
    }
}
