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
    public class IngredientLineRepository : IIngLineRepository//

    {
        private readonly string tableName = "ingredientlines";
        public IngredientLine Create(IngredientLine ingredientline)
        {
            string sql = $"INSERT INTO {tableName} (id_recipe, id_ingredient, quantity, id_measure)" + $"VALUES ({ingredientline.Recipe.Id}, {ingredientline.Ingredient.Id}, {ingredientline.Quantity}, {ingredientline.Measure.Id});";
            SQL.ExecuteNonQuery(sql);
            int id = SQL.GetMax("id", tableName);
            return Retrieve(id);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }



        public IngredientLine Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception(" not found.");
        }



       public List<IngredientLine> RetrieveAll()
         {
             string sql = $"SELECT * FROM {tableName};";
             SqlDataReader reader = SQL.Execute(sql);
             List<IngredientLine> ingredientline = new List<IngredientLine>();
             while (reader.Read())
             {
                 ingredientline.Add(Parse(reader));
             }
             return ingredientline;
         }

        public List<IngredientLine> RetrieveAllByRecipeId(int recipeId)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id_recipe = {recipeId};";
            SqlDataReader reader = SQL.Execute(sql);
            List<IngredientLine> ingredients = new List<IngredientLine>();
            while (reader.Read())
            {
                ingredients.Add(Parse(reader));
            }
            return ingredients;
        }


        public IngredientLine Update(IngredientLine ingredientLine)
        {

            string sql = $"UPDATE {tableName} SET " +
                $"id_ingredient = {ingredientLine.Ingredient.Id} " +
                $"quantity = {ingredientLine.Quantity} " +
                $"id_measure = {ingredientLine.Measure.Id}" +
                $"WHERE id = {ingredientLine.Id}";
            SQL.ExecuteNonQuery(sql);
            return Retrieve(ingredientLine.Id);
        }


        private IngredientLine Parse(SqlDataReader reader)
        {
            IngredientLine ingredientline = new IngredientLine();
            ingredientline.Id = Convert.ToInt32(reader["id"]);

            ingredientline.Quantity = Convert.ToDouble(reader["quantity"]);

            Recipe recipe = new Recipe();// dudas , ver con Jorge 
            recipe.Id = Convert.ToInt32(reader["id_recipe"]);
            ingredientline.Recipe = recipe;

            Ingredient ingredient = new Ingredient();
            ingredient.Id = Convert.ToInt32(reader["id_ingredient"]);
            ingredientline.Ingredient = ingredient;

            Measure measure = new Measure();
            measure.Id = Convert.ToInt32(reader["id_measure"]);
            ingredientline.Measure = measure;

            return ingredientline;
        }
    }
}
