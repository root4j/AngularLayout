using AngularLayout.Model.Entities.General;
using System.Collections.Generic;

namespace AngularLayout.Model.Business.General
{
    public interface ICityBusiness
    {
        void Create(City entity);
        void Delete(string id);
        City FindById(string id);
        List<City> GetAll();
        List<City> GetAllByStateCode(string stateCode);
        void Update(string id, City entity);
    }
}