using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using Recipes_Final.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes_Final.Service.Implementation
{
    public class MeasuresService : IService<Measure, int>
    {
        private readonly IRepository<Measure, int> _repository;

        public MeasuresService(IRepository<Measure, int> _repository)
        {
            this._repository = _repository;
        }
        //
        public Measure Create(Measure measure)
        {
            return _repository.Create(measure);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

       

        public Measure Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }

        public List<Measure> RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        public Measure Update(Measure measure)
        {
            return _repository.Update(measure);
        }
    }
}
