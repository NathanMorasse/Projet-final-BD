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
            int duration = reader.GetInt32("DureeAbility");
            string name = reader.GetString("NomAbility");
            string type = reader.GetString("TypeAbility");
            string diceToRoll = reader.GetString("DiceToRoll");
            string description = reader.GetString("DescriptionAbility");
            int distance = reader.GetInt32("Distance");

            Ability newAbility = new Ability(id, duration, name, type, diceToRoll, description, distance);
            return newAbility;
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
                    "VALUES(@Nom, @Duree, @Distance, \"Magic\", \"1d12\", \"Une grosse crisse de boule de feu\")";
                cmd.Parameters.AddWithValue("@Name", newAbility.Name);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
