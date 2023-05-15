using ProjetFinale.DataAccessLayer.Factory.FactoryBase;
using ProjetFinale.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows;

namespace ProjetFinale.DataAccessLayer.Factory
{
    internal class CharacterFact: FactBase
    {
        private Character CreateFromReader(MySqlDataReader reader)
        {
            int id = reader.GetInt32("IdCharacter");
            int level = reader.GetInt32("CharacterLevel");
            int health = reader.GetInt32("CharacterPv");
            string name = reader.GetString("CharacterName");

            Character newCharacter = new Character(id, level, health, name);
            return newCharacter;
        }

        private Character CreateFromReaderWithDate(Character character, DateTime dateModif)
        {
            int id = character.Id;
            string name = character.Name;
            int level = character.Level;
            DateTime date = dateModif;

            return new(id,name, level, date);
        }

        public List<Character> GetAllCharacters()
        {
            List<Character> characters = new List<Character>();
            MySqlConnection connection = null;
            MySqlDataReader reader = null;

            try
            {
                connection = new MySqlConnection(this.CnnStr);
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM tblcharacter";

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Character characterTemp = CreateFromReader(reader);
                    characters.Add(characterTemp);
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                connection.Close();
            }

            return characters;
        }

        public Character GetCharacterById(int id)
        {
            Character character = new Character();
            MySqlConnection connection = null;
            MySqlDataReader reader = null;

            try
            {
                connection = new MySqlConnection(this.CnnStr);
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM tblcharacter WHERE IdCharacter = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    character = CreateFromReader(reader);
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                connection.Close();
            }

            return character;
        }

        public List<Character> GetHighestLvlCharacters()
        {
            List<Character> characters = new List<Character>();
            MySqlConnection connection = null;
            MySqlDataReader reader = null;

            try
            {
                connection = new MySqlConnection(this.CnnStr);
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM HighestLvlCharacters";

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Character temp = GetCharacterById((int)reader["IdCharacter"]);
                    characters.Add(temp);
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                connection.Close();
            }

            return characters;
        }

        public List<Character> GetLastUpdatedCharacters()
        {
            List<Character> characters = new List<Character>();
            MySqlConnection connection = null;
            MySqlDataReader reader = null;

            try
            {
                connection = new MySqlConnection(this.CnnStr);
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM LastUpdatedCharacters";

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Character temp = GetCharacterById((int)reader["IdCharacter"]);
                    Character characterTemp = CreateFromReaderWithDate(temp, (DateTime)reader["LastUpdated"]);
                    characters.Add(characterTemp);
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                connection.Close();
            }

            return characters;
        }

        public void AddCharacter(Character newCharacter)
        {
            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection(this.CnnStr);
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "call bd_projetfinal.CreateCharacter(@Name, @Health, @Race, @Class, @Description, @Background, @Alignement)";
                cmd.Parameters.AddWithValue("@Name", newCharacter.Name);
                cmd.Parameters.AddWithValue("@Health", newCharacter.Health);
                cmd.Parameters.AddWithValue("@Race", newCharacter.Characteristics.Race);
                cmd.Parameters.AddWithValue("@Class", newCharacter.Characteristics.Classe);
                cmd.Parameters.AddWithValue("@Description", newCharacter.Characteristics.Description);
                cmd.Parameters.AddWithValue("@Background", newCharacter.Characteristics.Background);
                cmd.Parameters.AddWithValue("@Alignement", newCharacter.Characteristics.Alignement);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateCharacter(Character newCharacter)
        {
            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection(this.CnnStr);
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "call bd_projetfinal.UpdateCharacter(@Id, @Name, @Level, @Health, @Race, @Class, @Description, @Background, @Alignement, @Strength, @Dexterity, @Constitution, @Intelligence, @Wisdom, @Charisma, @Armor)";
                cmd.Parameters.AddWithValue("@Id", newCharacter.Id);
                cmd.Parameters.AddWithValue("@Name", newCharacter.Name);
                cmd.Parameters.AddWithValue("@Level", newCharacter.Level);
                cmd.Parameters.AddWithValue("@Health", newCharacter.Health);
                cmd.Parameters.AddWithValue("@Race", newCharacter.Characteristics.Race);
                cmd.Parameters.AddWithValue("@Class", newCharacter.Characteristics.Classe);
                cmd.Parameters.AddWithValue("@Description", newCharacter.Characteristics.Description);
                cmd.Parameters.AddWithValue("@Background", newCharacter.Characteristics.Background);
                cmd.Parameters.AddWithValue("@Alignement", newCharacter.Characteristics.Alignement);
                cmd.Parameters.AddWithValue("@Strength", newCharacter.Statistics.Strength);
                cmd.Parameters.AddWithValue("@Dexterity", newCharacter.Statistics.Dexterity);
                cmd.Parameters.AddWithValue("@Constitution", newCharacter.Statistics.Constitution);
                cmd.Parameters.AddWithValue("@Intelligence", newCharacter.Statistics.Intelligence);
                cmd.Parameters.AddWithValue("@Wisdom", newCharacter.Statistics.Wisdom);
                cmd.Parameters.AddWithValue("@Charisma", newCharacter.Statistics.Charisma);
                cmd.Parameters.AddWithValue("@Armor", newCharacter.Statistics.Armor);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteCharacter(Character character)
        {
            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection(this.CnnStr);
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Delete FROM tblcharacter WHERE IdCharacter = @Id";
                cmd.Parameters.AddWithValue("@Id", character.Id);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
