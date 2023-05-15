using ProjetFinale.DataAccessLayer.Factory.FactoryBase;
using ProjetFinale.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
