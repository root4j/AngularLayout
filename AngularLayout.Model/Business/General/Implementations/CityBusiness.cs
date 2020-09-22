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
    public class CityBusiness : ICityBusiness
    {
        private readonly DefaultContext _context;

        public CityBusiness(DefaultContext Context)
        {
            _context = Context;
        }

        public void Create(City entity)
        {
            try
            {
                City obj = FindById(entity.CityCode);
                if (obj == null)
                {
                    entity.CreationDate = DateTimeOffset.Now;
                    entity.ModificationDate = DateTimeOffset.Now;
                    _context.Cities.Add(entity);
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
                City entity = FindById(id);
                if (entity != null)
                {
                    _context.Cities.Remove(entity);
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

        public City FindById(string id)
        {
            try
            {
                return _context.Cities.AsNoTracking().Where(x => x.CityCode.Equals(id)).SingleOrDefault();
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex.Message, ex);
                throw;
            }
        }

        public List<City> GetAll()
        {
            try
            {
                return _context.Cities.Include(x => x.State).ThenInclude(x => x.Country).OrderBy(x => x.CityCode).ToList();
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex.Message, ex);
                throw;
            }
        }

        public List<City> GetAllByStateCode(string stateCode)
        {
            try
            {
                return _context.Cities.Include(x => x.State).ThenInclude(x => x.Country).Where(x => x.StateCode.Equals(stateCode)).OrderBy(x => x.CityCode).ToList();
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex.Message, ex);
                throw;
            }
        }

        public void Update(string id, City entity)
        {
            try
            {
                City obj = FindById(id);
                if (obj != null)
                {
                    if (entity.CityCode == obj.CityCode)
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
