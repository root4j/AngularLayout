using AngularLayout.Model.Common.Exceptions;
using AngularLayout.Model.Common.Loggers;
using AngularLayout.Model.Context;
using AngularLayout.Model.Entities.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngularLayout.Model.Business.General.Implementations
{
    public class ValueListBusiness : IValueListBusiness
    {
        private readonly DefaultContext _context;

        public ValueListBusiness(DefaultContext Context)
        {
            _context = Context;
        }

        public void Create(ValueList entity)
        {
            try
            {
                ValueList obj = FindById(entity.ValueListCode);
                if (obj == null)
                {
                    entity.CreationDate = DateTimeOffset.Now;
                    entity.ModificationDate = DateTimeOffset.Now;
                    _context.ValueLists.Add(entity);
                    _context.SaveChanges();
                }
                else
                {
                    throw new EqualUniqueRowException();
                }
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex.Message, ex);
                throw;
            }
        }

        public void Delete(string id)
        {
            try
            {
                ValueList entity = FindById(id);
                if (entity != null)
                {
                    _context.ValueLists.Remove(entity);
                    _context.SaveChanges();
                }
                else
                {
                    throw new NonObjectFoundException();
                }
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex.Message, ex);
                throw;
            }
        }

        public ValueList FindById(string id)
        {
            try
            {
                return _context.ValueLists.AsNoTracking().Where(x => x.ValueListCode.Equals(id)).SingleOrDefault();
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex.Message, ex);
                throw;
            }
        }

        public List<ValueList> GetAll()
        {
            try
            {
                return _context.ValueLists.OrderBy(x => x.ValueListCategory).ThenBy(x => x.ListOrder).ToList();
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex.Message, ex);
                throw;
            }
        }

        public List<ValueList> GetAllByCategory(string category)
        {
            try
            {
                return _context.ValueLists.Where(x => x.ValueListCategory.Equals(category)).OrderBy(x => x.ListOrder).ToList();
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex.Message, ex);
                throw;
            }
        }

        public void Update(string id, ValueList entity)
        {
            try
            {
                ValueList obj = FindById(id);
                if (obj != null)
                {
                    if (entity.ValueListCode == obj.ValueListCode)
                    {
                        entity.ModificationDate = DateTimeOffset.Now;
                        _context.Entry(entity).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                    else
                    {
                        throw new NonEqualObjectException();
                    }
                }
                else
                {
                    throw new NonObjectFoundException();
                }
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex.Message, ex);
                throw;
            }
        }
    }
}