using Recipes_Final.Model;
using Recipes_Final.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes_Final.Repository.Implementation
{
    public class PostRepository : IRepository<Post, int>
    {
        private readonly string tableName = "posts";
        public Post Create(Post post)//
        {
            string sql = $"INSER INTO {tableName} (id_users, id_recipes, comments, ratting )" + $"VALUES ({post.User.Id}, {post.Recipes.Id}, {post.Comment}, {post.Rattings});";
            SQL.ExecuteNonQuery(sql);
            int id = SQL.GetMax("id", tableName);
            return Retrieve(id);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        

        public Post Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception("Favorite recipe not found.");
        }

        public List<Post> RetrieveAll()
        {
            string sql = $"SELECT * FROM {tableName};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Post> post = new List<Post>();
            while (reader.Read())
            {
                post.Add(Parse(reader));
            }
            return post;
        }

        public Post Update(Post post)
        {
            string sql = $"UPDATE {tableName} SET" +
                 $"id_users = {post.User.Id}, " +
                 $"id_recipes = {post.Recipes.Id}" +
                 $"comments = {post.Comment}" +
                 $"ratting = {post.Rattings}" +
                 $"WHERE id = {post.Id}";
            SQL.ExecuteNonQuery(sql);
            return Retrieve(post.Id);
        }

        private Post Parse(SqlDataReader reader)
        {
            Post post = new Post();
            post.Id = Convert.ToInt32(reader["id"]);
            post.Comment = Convert.ToString(reader["comment"]);
            post.Rattings = Convert.ToInt32(reader["ratting"]);

            User user = new User();
            user.Id = Convert.ToInt32(reader["id_user"]);
            post.User = user;

            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(reader["id_recipe"]);
            post.Recipes = recipe;

            return post;
        }
    }
}
