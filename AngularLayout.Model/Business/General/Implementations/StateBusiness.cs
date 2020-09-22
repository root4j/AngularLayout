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
    public class StateBusiness : IStateBusiness
    {
        private readonly DefaultContext _context;

        public StateBusiness(DefaultContext Context)
        {
            _context = Context;
        }

        public void Create(State entity)
        {
            try
            {
                State obj = FindById(entity.StateCode);
                if (obj == null)
                {
                    entity.CreationDate = DateTimeOffset.Now;
                    entity.ModificationDate = DateTimeOffset.Now;
                    _context.States.Add(entity);
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
                State entity = FindById(id);
                if (entity != null)
                {
                    _context.States.Remove(entity);
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

        public State FindById(string id)
        {
            try
            {
                return _context.States.AsNoTracking().Where(x => x.StateCode.Equals(id)).SingleOrDefault();
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex.Message, ex);
                throw;
            }
        }

        public List<State> GetAll()
        {
            try
            {
                return _context.States.Include(x => x.Country).OrderBy(x => x.CountryCode).ThenBy(x => x.StateCode).ToList();
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex.Message, ex);
                throw;
            }
        }

        public List<State> GetAllByCountryCode(string countryCode)
        {
            try
            {
                return _context.States.Include(x => x.Country).Where(x => x.CountryCode.Equals(countryCode)).OrderBy(x => x.StateCode).ToList();
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex.Message, ex);
                throw;
            }
        }

        public void Update(string id, State entity)
        {
            try
            {
                State obj = FindById(id);
                if (obj != null)
                {
                    if (entity.StateCode == obj.StateCode)
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