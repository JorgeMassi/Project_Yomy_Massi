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
    public class SearchRepository : ISearchRepository
    {
        public List<Search> RetrieveAllByCategory(int catid)
        {
            string sql = $"SELECT * FROM categories INNER JOIN recipes ON categories.id = recipes.id_category " +
                $"WHERE(categories.id) LIKE {catid};";

            SqlDataReader dataReader = SQL.Execute(sql);
            List<Search> searchByCategory = new List<Search>();
            while (dataReader.Read())
            {
                Search search = Parse(dataReader);
                searchByCategory.Add(search);
            }
            return searchByCategory;
        }

        private Search Parse(SqlDataReader reader)
        {
            Search search = new Search();//
            search.Id = Convert.ToInt32(reader["id"]);
           
            search.Title= Convert.ToString(reader["title"]);

            User author = new User();
            author.Id = Convert.ToInt32(reader["id_user"]);
            search.Author = author;

            Category category = new Category();
            category.Id = Convert.ToInt32(reader["id_category"]);
            search.Category = category;

            search.PreparationTime = Convert.ToInt32(reader["prep_time"]);
            search.PreparationMethod = Convert.ToString(reader["prep_method"]);

            Difficulty difficulty = new Difficulty();
            difficulty.Id = Convert.ToInt32(reader["id_difficulty"]);
            search.Difficulty = difficulty;

            search.IsApproved = Convert.ToBoolean(reader["is_approved"]);

            return search;
            
        }
    }
}
