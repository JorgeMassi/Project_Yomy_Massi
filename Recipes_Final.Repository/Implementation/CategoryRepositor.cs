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
    public class CategoryRepository : IRepository<Category, int>
    {
        private readonly string tableName = "categories";
        public Category Create(Category category)
        {
            string sql = $"INSERT INTO {tableName} (name) Values ('{category.Name}');";
            SQL.ExecuteNonQuery(sql);
            int id = SQL.GetMax("id", tableName);
            return Retrieve(id);
            
        }

        public void Delete(int id)
        {
            string sql = $"DELETE From {tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);

        }
        

        public Category Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read()) 
            {
                return Parse(reader);
            }throw new Exception("Category not found");
        }

        public List<Category> RetrieveAll()
        {
            string sql = $"SELECT * FROM {tableName};";
            SqlDataReader reader= SQL.Execute(sql);
            List<Category> categories = new List<Category>();
            while (reader.Read()) 
            {
                categories.Add(Parse(reader)); 

            }return categories;
        }

        public Category Update(Category category)
        {
            string sql = $"UPDATE {tableName} SET name = '{category.Name}' WHERE id = {category.Id}";
            SQL.Execute(sql);
            return Retrieve(category.Id);
        }

        private Category Parse(SqlDataReader reader)
        {
            Category category = new Category();
            category.Id = Convert.ToInt32(reader["id"]);
            category.Name = Convert.ToString(reader["name"]);
            return category;
        }

    }
}
