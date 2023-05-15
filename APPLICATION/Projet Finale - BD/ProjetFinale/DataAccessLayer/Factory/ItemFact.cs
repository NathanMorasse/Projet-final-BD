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
    internal class ItemFact: FactBase
    {
        private Item CreateFromReader(MySqlDataReader reader)
        {
            int id = reader.GetInt32("IdObject");
            string name = reader.GetString("ObjectName");

            string diceToRoll;
            if (reader["DiceToRoll"] == null || reader["DiceToRoll"].ToString() == "" || reader["DiceToRoll"].ToString() == string.Empty)
            {
                diceToRoll = "Aucun";
            }
            else
            {
                diceToRoll = reader["DiceToRoll"].ToString();
            }
            string description = reader.GetString("ObjectDescription");
            int weight = reader.GetInt32("Weight");

            Item newItem = new Item(id, name, diceToRoll, description, weight);
            return newItem;
        }

        public List<Item> GetAllItems()
        {
            List<Item> items = new List<Item>();
            MySqlConnection connection = null;
            MySqlDataReader reader = null;

            try
            {
                connection = new MySqlConnection(this.CnnStr);
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM tblobject";

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Item itemTemp = CreateFromReader(reader);
                    items.Add(itemTemp);
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

            return items;
        }

        public Item GetItemById(int id)
        {
            Item item = new Item();
            MySqlConnection connection = null;
            MySqlDataReader reader = null;

            try
            {
                connection = new MySqlConnection(this.CnnStr);
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM tblobject WHERE IdObject = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    item = CreateFromReader(reader);
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

            return item;
        }

        public void AddItem(Item newItem)
        {
            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection(this.CnnStr);
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO tblobject (ObjectName, DiceToRoll, ObjectDescription, Weight) " +
                    "VALUES(@Name, @DiceToRoll, @Description, @Weight)";
                cmd.Parameters.AddWithValue("@Name", newItem.Name);
                cmd.Parameters.AddWithValue("@DiceToRoll", newItem.DiceToRoll);
                cmd.Parameters.AddWithValue("@Description", newItem.Description);
                cmd.Parameters.AddWithValue("@Weight", newItem.Weight);

                cmd.ExecuteNonQuery();
                newItem.Id = (int)cmd.LastInsertedId;
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteItem(Item item)
        {
            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection(this.CnnStr);
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM tblobject " +
                    "WHERE IdObject = @Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
