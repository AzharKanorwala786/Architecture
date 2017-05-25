using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Data.Data;
using System.Data.Entity.Infrastructure;

namespace Data.Repositories
{
   //Implementing Generic UOW

   public class UOW : IUOW
    {
        // Create Context Object
        private DataContext context = new DataContext();

        // For Creating Multiple Repositories
        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        private bool disposed = false;

        // Return Repositories

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (!repositories.ContainsKey(typeof(T)))
            {
                repositories.Add(typeof(T), ReturnRepository<T>(typeof(Repository<>)));
            }
            return repositories[typeof(T)] as IGenericRepository<T>;
        }

        // Cascaded Return Generic Repository

        private IGenericRepository<T> ReturnRepository<T>(Type BaseGenericType) where T : class
        {
          
            IGenericRepository<T>  EntityRepository;

            BaseGenericType = BaseGenericType == null ? typeof(Repository<>) : BaseGenericType;

            Type[] TypeArgs = { typeof(T) };

            Type GenericClass = BaseGenericType.MakeGenericType(TypeArgs);

            EntityRepository = (IGenericRepository<T>)Activator.CreateInstance(GenericClass, context);

            return EntityRepository;

        }


        // Save Changes 
        public void SaveChanges()
        {
            try
            {
                context.SaveChanges();
            }

            catch (DbUpdateConcurrencyException ex)
            {
                 ex.Entries.Single().Reload();
            }
        }


        //Close the context
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
