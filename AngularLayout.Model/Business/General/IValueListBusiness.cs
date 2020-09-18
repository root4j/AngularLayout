using AngularLayout.Model.Entities.General;
using System.Collections.Generic;

namespace AngularLayout.Model.Business.General
{
    public interface IValueListBusiness
    {
        void Create(ValueList entity);
        void Delete(string id);
        ValueList FindById(string id);
        List<ValueList> GetAll();
        List<ValueList> GetAllByCategory(string category);
        void Update(string id, ValueList entity);
    }
}