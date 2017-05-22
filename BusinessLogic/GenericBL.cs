using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using Data.Repositories;
using Core.Interfaces;

namespace BusinessLogic
{
    public class GenericBL<Entity> : IGenericBL<Entity> where Entity : class
    {
        private IUOW UnitOfWork;

        private bool disposed = false;

        public IUOW UOWP
        {
            get { return UnitOfWork; }
        }

        public GenericBL(IUOW UOW)
        {
            UnitOfWork = UOW;
        }

        public virtual void Insert(Entity entity)
        {
            UnitOfWork.Repository<Entity>().Insert(entity);
        }

        public void Update(Entity entityObj)
        {
            UnitOfWork.Repository<Entity>().Update(entityObj);
        }

        public virtual void Delete<T>(T Id)
        {
            UnitOfWork.Repository<Entity>().Delete<T>(Id);
        }

        protected Entity FindbyId<T>(T Id)
        {
            return UnitOfWork.Repository<Entity>().FindById<T>(Id);
        }

        protected IEnumerable<Entity> GetAllProd()
        {
            return UnitOfWork.Repository<Entity>().GetAllProducts();
        }

        protected IQueryable<Entity> GetWhere(System.Linq.Expressions.Expression<Func<Entity, bool>> where)
        {
            return UnitOfWork.Repository<Entity>().GetWhere(where);
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
