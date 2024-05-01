using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using Recipes_Final.Repository.Interface;
using Recipes_Final.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes_Final.Service.Implementation
{
    public class IngredientLineService : IIngLineService
    {
        public readonly IIngLineRepository _ingredientLineRepository;

        public readonly IService<Ingredient, int> _ingredientService;//
        public readonly IService<Measure, int> _measureService;

        public IngredientLineService(IIngLineRepository ingredientLineRepository, IService<Ingredient, int> ingredientService, IService<Measure, int> measureService)
        {
            _ingredientLineRepository = ingredientLineRepository;
            _ingredientService = ingredientService;
            _measureService = measureService;
        }

        public IngredientLine Create(IngredientLine ingredientLine)
        {
            return _ingredientLineRepository.Create(ingredientLine);
        }

        public void Delete(int id)
        {
            _ingredientLineRepository.Delete(id);
        }



        public IngredientLine Retrieve(int id)
        {
            return _ingredientLineRepository.Retrieve(id);
        }


        public IngredientLine Update(IngredientLine ingredientLine)
        {
            return _ingredientLineRepository.Update(ingredientLine);
        }

        public List<IngredientLine> RetrieveAll() 
        {
            return _ingredientLineRepository.RetrieveAll();
        }
        
       

        public List<IngredientLine> RetrieveAllByRecipeId(Recipe recipe)
        {
            List<IngredientLine> ingredientLines = _ingredientLineRepository.RetrieveAllByRecipeId(recipe.Id);


            foreach (IngredientLine ingredientLine in ingredientLines)
            {

                ingredientLine.Recipe = recipe;
                ingredientLine.Measure = _measureService.Retrieve(ingredientLine.Measure.Id);
                ingredientLine.Ingredient = _ingredientService.Retrieve(ingredientLine.Ingredient.Id);

               
            }
            return ingredientLines;
        }

       

        /* public IngredientLine Update(IngredientLine type)
         {
             throw new NotImplementedException();
         }

         IngredientLine IIngredientLineService.Update(int id)
         {
             throw new NotImplementedException();
         }*/
    }
}
