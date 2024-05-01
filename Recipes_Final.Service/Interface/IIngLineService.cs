using Recipes_Final.Model;


namespace Recipes_Final.Service.Interface
{
    public interface IIngLineService
    {
        IngredientLine Create(IngredientLine ingredientLine);
        IngredientLine Retrieve(int id);
        List<IngredientLine> RetrieveAllByRecipeId(Recipe recipe);
        IngredientLine Update(IngredientLine ingredientLine);
        List<IngredientLine> RetrieveAll();
        void Delete(int id);
    }//
}
