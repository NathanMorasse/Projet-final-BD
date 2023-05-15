using MySql.Data.MySqlClient;
using ProjetFinale.Models;
using ProjetFinale.DataAccessLayer.Factory.FactoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinale.DataAccessLayer.Factory
{
    internal class AbilityFact: FactBase
    {
        private Ability CreateFromReader(MySqlDataReader reader)
        {
            int id = reader.GetInt32("IdAbility");
            string rechargement = reader.GetString("Rechargement");
            string name = reader.GetString("NomAbility");
            string type = reader.GetString("TypeAbility");
            string diceToRoll = reader.GetString("DiceToRoll");
            string description = reader.GetString("DescriptionAbility");
            int distance = reader.GetInt32("Distance");

            Ability newAbility = new Ability(id, rechargement, name, type, diceToRoll, description, distance);
            return newAbility;
        }

        public List<Ability> GetAllAbilities()
        {
            List<Ability> abilities = new List<Ability>();
            MySqlConnection connection = null;
            MySqlDataReader reader = null;

            try
            {
                connection = new MySqlConnection(this.CnnStr);
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM tblability";

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Ability abilityTemp = CreateFromReader(reader);
                    abilities.Add(abilityTemp);
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

            return abilities;
        }

        public Ability GetAbilityById(int id)
        {
            Ability ability = new Ability();
            MySqlConnection connection = null;
            MySqlDataReader reader = null;

            try
            {
                connection = new MySqlConnection(this.CnnStr);
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM tblAbility WHERE IdAbility = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ability = CreateFromReader(reader);
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

            return ability;
        }

        public void AddAbility(Ability newAbility)
        {
            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection(this.CnnStr);
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO tblability (NomAbility, DureeAbility, Distance, TypeAbility, DiceToRoll, DescriptionAbility) " +
                    "VALUES(@Name, @Duration, @Distance, @Type, @DiceToRoll, @Description)";
                cmd.Parameters.AddWithValue("@Name", newAbility.Name);
                cmd.Parameters.AddWithValue("@Duration", newAbility.Duration);
                cmd.Parameters.AddWithValue("@Distance", newAbility.Distance);
                cmd.Parameters.AddWithValue("@Type", newAbility.Type);
                cmd.Parameters.AddWithValue("@DiceToRoll", newAbility.DiceToRoll);
                cmd.Parameters.AddWithValue("@Description", newAbility.Description);

                cmd.ExecuteNonQuery();
                newAbility.Id = (int)cmd.LastInsertedId;
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteAbility(Ability ability)
        {
            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection(this.CnnStr);
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE * FROM tblability " +
                    "WHERE IdAbility = @IdAbility";
                cmd.Parameters.AddWithValue("@IdAbility", ability.Id);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void AddAbilityToCharacter(int idCharacter, int idAbility)
        {
            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection(this.CnnStr);
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO tblcharacterability " +
                    "VALUES(@IdCharacter, @IdAbility)";
                cmd.Parameters.AddWithValue("@IdCharacter", idCharacter);
                cmd.Parameters.AddWithValue("@IdAbility", idAbility);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void RemoveAbilityFromCharacter(int idCharacter, int idAbility)
        {
            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection(this.CnnStr);
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE * FROM tblcharacterability " +
                    "WHERE IdPerso = @IdCharacter " +
                    "AND IdAbility = @IdAbility";
                cmd.Parameters.AddWithValue("@IdCharacter", idCharacter);
                cmd.Parameters.AddWithValue("@IdAbility", idAbility);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
