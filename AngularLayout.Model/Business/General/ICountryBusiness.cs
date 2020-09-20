using AngularLayout.Model.Entities.General;
using System.Collections.Generic;

namespace AngularLayout.Model.Business.General
{
    public interface ICountryBusiness
    {
        void Create(Country entity);
        void Delete(string id);
        Country FindById(string id);
        List<Country> GetAll();
        void Update(string id, Country entity);
    }
}