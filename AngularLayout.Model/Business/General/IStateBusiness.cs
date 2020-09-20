using AngularLayout.Model.Entities.General;
using System.Collections.Generic;

namespace AngularLayout.Model.Business.General
{
    public interface IStateBusiness
    {
        void Create(State entity);
        void Delete(string id);
        State FindById(string id);
        List<State> GetAll();
        List<State> GetAllByCountryCode(string countryCode);
        void Update(string id, State entity);
    }
}