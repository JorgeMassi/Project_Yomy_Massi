using Recipes_Final.Model;

namespace Recipes_Final.Repository.Interface
{
    public interface IIngLineRepository
    {
        IngredientLine Create(IngredientLine ingredientLine);
        IngredientLine Retrieve(int id);
        List<IngredientLine> RetrieveAllByRecipeId(int recipeId);

        IngredientLine Update(IngredientLine ingredientLine);

        List<IngredientLine> RetrieveAll();
        void Delete(int id);//
    }
}
