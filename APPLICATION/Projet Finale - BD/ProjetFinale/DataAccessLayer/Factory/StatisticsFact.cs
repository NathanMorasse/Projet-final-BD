using MySql.Data.MySqlClient;
using ProjetFinale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinale.DataAccessLayer.Factory
{
    internal class StatisticsFact
    {
        private Statistics CreateFromReader(MySqlDataReader reader)
        {
            int id = reader.GetInt32("IdStats");
            int strength = reader.GetInt32("ForcePerso");
            int dexterity = reader.GetInt32("DexteritePerso");
            int constitution = reader.GetInt32("Constitution");
            int id = reader.GetInt32("IntelligencePerso");
            int id = reader.GetInt32("SagessePerso");
            int id = reader.GetInt32("CharismePerso");
            int id = reader.GetInt32("ArmurePerso");

            Statistics newSatitistics = new Statistics(id, level, health, name);
            return newSatitistics;
        }
    }
}
