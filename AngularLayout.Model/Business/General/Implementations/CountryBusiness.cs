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
    public class CountryBusiness : ICountryBusiness
    {
        private readonly DefaultContext _context;

        public CountryBusiness(DefaultContext Context)
        {
            _context = Context;
        }

        public void Create(Country entity)
        {
            try
            {
                Country obj = FindById(entity.CountryCode);
                if (obj == null)
                {
                    entity.CreationDate = DateTimeOffset.Now;
                    entity.ModificationDate = DateTimeOffset.Now;
                    _context.Countries.Add(entity);
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
                Country entity = FindById(id);
                if (entity != null)
                {
                    _context.Countries.Remove(entity);
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

        public Country FindById(string id)
        {
            try
            {
                return _context.Countries.AsNoTracking().Where(x => x.CountryCode.Equals(id)).SingleOrDefault();
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Country> GetAll()
        {
            try
            {
                return _context.Countries.OrderBy(x => x.CountryCode).ToList();
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex.Message, ex);
                throw;
            }
        }

        public void Update(string id, Country entity)
        {
            try
            {
                Country obj = FindById(id);
                if (obj != null)
                {
                    if (entity.CountryCode == obj.CountryCode)
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