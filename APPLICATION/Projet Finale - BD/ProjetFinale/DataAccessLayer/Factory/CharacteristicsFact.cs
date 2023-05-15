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
    internal class CharacteristicsFact: FactBase
    {
        private Characteristics CreateFromReader(MySqlDataReader reader)
        {
            int id = reader.GetInt32("IdCharacteristics");
            string classe = reader.GetString("Class");
            string race = reader.GetString("Race");
            string description = reader.GetString("PersoDescription");
            string background = reader.GetString("PersoBackGround");
            string alignement = reader.GetString("Alignement");

            Characteristics newCharacteristics = new Characteristics(id, classe, race, description, background, alignement);
            return newCharacteristics;
        }

        public Characteristics GetCharacteristicsByCharacterId(int id)
        {
            Characteristics characteristics = new Characteristics();
            MySqlConnection connection = null;
            MySqlDataReader reader = null;

            try
            {
                connection = new MySqlConnection(this.CnnStr);
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM tblcharacteristics WHERE IdPerso = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    characteristics = CreateFromReader(reader);
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

            return characteristics;
        }
    }
}
