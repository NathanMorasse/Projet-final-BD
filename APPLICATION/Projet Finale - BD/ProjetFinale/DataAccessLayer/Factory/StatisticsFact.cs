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
    internal class StatisticsFact: FactBase
    {
        private Statistics CreateFromReader(MySqlDataReader reader)
        {
            int id = reader.GetInt32("IdStats");
            int strength = reader.GetInt32("ForcePerso");
            int dexterity = reader.GetInt32("DexteritePerso");
            int constitution = reader.GetInt32("ConstitutionPerso");
            int intelligence = reader.GetInt32("IntelligencePerso");
            int wisdom = reader.GetInt32("SagessePerso");
            int charisma = reader.GetInt32("CharismePerso");
            int armor = reader.GetInt32("ArmurePerso");

            Statistics newSatitistics = new Statistics(id, strength, dexterity, constitution, intelligence, wisdom, charisma, armor);
            return newSatitistics;
        }

        public Statistics GetStatisticsByCharacterId(int id)
        {
            Statistics statistics = new Statistics();
            MySqlConnection connection = null;
            MySqlDataReader reader = null;

            try
            {
                connection = new MySqlConnection(this.CnnStr);
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM tblStatistics WHERE IdPerso = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    statistics = CreateFromReader(reader);
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

            return statistics;
        }
    }
}
