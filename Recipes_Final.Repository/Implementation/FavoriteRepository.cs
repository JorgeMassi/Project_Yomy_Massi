using Recipes_Final.Model;
using Recipes_Final.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes_Final.Repository.Implementation
{//
    public class FavoriteRepository : IRepository<Favorite, int>
    {
        private readonly string tableName = "favorites";
        public Favorite Create(Favorite favorite)
        {
            string sql = $"INSER INTO {tableName} (id_users, id_recipes)" + $"VALUES ({favorite.User.Id}, {favorite.Recipe.Id});";
            SQL.ExecuteNonQuery(sql);
            int id = SQL.GetMax("id", tableName);
            return Retrieve(id);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        

        public Favorite Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception("Favorite recipe not found.");
        }


        public List<Favorite> RetrieveAll()
        {
            string sql = $"SELECT * FROM {tableName};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Favorite> favorite = new List<Favorite>();
            while (reader.Read())
            {
                favorite.Add(Parse(reader));
            }
            return favorite;
        }

        public Favorite Update(Favorite favorite)
        {
            string sql = $"UPDATE {tableName} SET" +
                $"id_users = {favorite.User.Id}," +
                $"WHERE id = {favorite.Id}";
            SQL.ExecuteNonQuery(sql);
            return Retrieve(favorite.Id);
        }

        private Favorite Parse(SqlDataReader reader)
        {
            Favorite favorite = new Favorite();
            favorite.Id = Convert.ToInt32(reader["id"]);

            User user = new User();
            user.Id = Convert.ToInt32(reader["id_users"]);
            favorite.User = user;

            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(reader["id_recipes"]);
            favorite.Recipe = recipe;

            return favorite;
        }
    }
}

