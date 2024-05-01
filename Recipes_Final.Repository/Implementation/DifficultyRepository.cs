using Recipes_Final.Model;
using Recipes_Final.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Recipes_Final.Repository.Implementation
{
    public class DifficultyRepository : IRepository<Difficulty, int>
    {
        private readonly string tableName = "difficulties";
        public Difficulty Create(Difficulty difficulty)
        {
            string sql = $"INSERT INTO {tableName} (name) VALUES ('{difficulty.Name}');";
            SQL.ExecuteNonQuery(sql);
            int id = SQL.GetMax("id", tableName);
            return Retrieve(id);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

    

        public Difficulty Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id= {id};";
            SqlDataReader reader = SQL.Execute(sql); // preguntar por qué no directamente SQL.ExecuteNonQuery(sql)
            if (reader.Read())
            {
                return Parse(reader);
            }
           throw new Exception("Difficulty not found.");
        }
        public List<Difficulty> RetrieveAll()
        {
            string sql = $"SELECT * FROM {tableName};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Difficulty> difficulties = new List<Difficulty>();
            while (reader.Read()) 
            {
            difficulties.Add(Parse(reader));
            }return difficulties;   
        }

        public Difficulty Update(Difficulty difficulties)
        {
            string sql = $"UPDATE {tableName} SET name = '{difficulties.Name}' WHERE id = {difficulties.Id}";
            SQL.ExecuteNonQuery(sql);
            return Retrieve(difficulties.Id);
        }

        private Difficulty Parse(SqlDataReader reader)
        {
            Difficulty difficulty = new Difficulty();
            difficulty.Id = Convert.ToInt32(reader["id"]);
            difficulty.Name = Convert.ToString(reader["name"]); // Porque los curly en verde.
            return difficulty;
        }

    }
}
