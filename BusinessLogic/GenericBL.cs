using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Data;
using Core.ViewModels;
using Core.Models;
using BusinessLogic.Interfaces;

namespace BusinessLogic
{
    public class GenericBL<Entity> : IGenericBL<Entity> where Entity : class
    {
        private IUOW UnitOfWork;

        private bool disposed = false;

        public IUOW UOW
        {
            get { return UnitOfWork; }
        }

        public GenericBL(IUOW UnitOfWorks)
        {
            UnitOfWork = UnitOfWorks;
        }

        protected IEnumerable<Entity> GetAll()
        {
            return UnitOfWork.Repository<Entity>().GetAllProducts();
        }

        protected Entity GetbyID<T>(T Identity)
        {
            return UnitOfWork.Repository<Entity>().FindById<T>(Identity);
        }

        protected IQueryable<Entity> GetWhere(System.Linq.Expressions.Expression<Func<Entity, bool>> where)
        {
            return UnitOfWork.Repository<Entity>().GetWhere(where);
        }

        public virtual void Insert(Entity Entry)
        {
            UnitOfWork.Repository<Entity>().Insert(Entry);

        }

        public virtual void Delete<T>(T Identity)
        {
            UnitOfWork.Repository<Entity>().Delete<T>(Identity);

        }

        public virtual void Update(Entity EntityObject)
        {
            UnitOfWork.Repository<Entity>().Update(EntityObject);

        }

        public void SaveChanges()
        {
            UnitOfWork.SaveChanges();

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    UnitOfWork.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
