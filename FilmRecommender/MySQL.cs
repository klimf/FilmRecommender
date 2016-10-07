using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FilmRecommender
{
    public class MySQL
    {
        string connect = "Database=host1416746_lod;Data Source=klim.me;User Id=host1416746_lod;Password=veryBadPassword";
        public string Connect(string commandText, string GetOrSet)
        {
            MySqlConnection connection = new MySqlConnection(connect);
            MySqlCommand command = new MySqlCommand(commandText, connection);
            string result;
            connection.Open();

            if (GetOrSet == "get")
            {
                result =  command.ExecuteScalar().ToString();
            }
            else if(GetOrSet == "set")
            {
                command.ExecuteNonQuery();
                result = commandText;
            }
            else
                result = "error";

            connection.Close();
            return result;
        }
        public string GetFieldValueById(string table, string field, int id)
        {
            return GetFieldValueByField(table, field, "id", id+"");
        }
        public string SetFieldValue(string table, string field, string value)
        {
            return Connect("INSERT INTO " + table + " (" + field + ") VALUES('" + value + "')", "set");
        }
        public string SetFieldValueById(string table, int id, string field, string value)
        {
            return Connect("UPDATE " + table + " SET " + field + " = '" + value + "' WHERE id = '" + id + "'", "set");
        }
        public string UpdateFieldValueById(string table, int id, string field, string value)
        {
            return Connect("UPDATE " + table + " SET " + field + " = CONCAT(" + field + ", '" + value + "') WHERE id = '" + id + "'", "set");
        }
        public string GetFieldValueByField(string table, string field, string fieldFind, string fieldValue)
        {
            return Connect("SELECT " + field + " FROM " + table + " WHERE " + fieldFind + " = '" + fieldValue + "'", "get");
        }
        public string Count(string table)
        {
            return Connect("SELECT COUNT(*) FROM " + table, "get");
        }
        /*public string DeleteValue(string nameOfValue)
        {
            return Connect("DELETE FROM Variations WHERE name = '" + nameOfValue + "'", "set");
        }
        public string GetValue(string nameOfValue)
        {
            return GetFieldValueByField("Variations", "value", "name", nameOfValue);
        }
        public string SetValue(string nameOfValue,int value)
        {
            return "none";
        }*/

    }
}
