using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Core.Interfaces;
using Data.Data;


namespace Data.Repositories
{
    //Implementing Generic Repository

    public class Repository<Entity> : IGenericRepository<Entity> where Entity : class
    {

        //calling Datacontext from Data
        public DataContext cbcontext;

        //Creating  a custom dbset for storing entites
        private DbSet<Entity> EntityDbSet;

        //Look for small s in following property
        public DbSet EntityDbset
        {
            get { return EntityDbSet; }
        }

        //Intialize Repository
        public Repository(DataContext context)
        {
            cbcontext = context;
            EntityDbSet = cbcontext.Set<Entity>();
        }

        //Insert 
        public virtual void Insert(Entity entity)
        {
            EntityDbSet.Add(entity);        
        }

        //Update
        public virtual void Update(Entity entityObj)
        {
            EntityDbSet.Attach(entityObj);
            cbcontext.Entry(entityObj).State = EntityState.Modified;
        }

        //When Data Does not Exist
        public virtual void Delete<T>(T Id)
        {
            Entity Entity = EntityDbSet.Find(Id);

            if (Entity != null)
            {
                Delete(Entity);
            }
            else
            {
                throw new ApplicationException("Could not find ID : " + Id.ToString());
            }
        }

        //Delete
        public virtual void Delete(Entity entityObj)
        {
            if (cbcontext.Entry(entityObj).State == EntityState.Detached)
            {
                EntityDbSet.Attach(entityObj);
            }
            EntityDbSet.Remove(entityObj);
        }

        //Find By Id
        public Entity FindById<T>(T Id)
        {
            return EntityDbSet.Find(Id);
        }

        //Get All 
        public IEnumerable<Entity> GetAllProducts()
        {
            return EntityDbSet.ToList();
        }
        
        //Get by specific condition
        public virtual IQueryable<Entity> GetWhere(System.Linq.Expressions.Expression<Func<Entity, bool>> where)
        {
            return EntityDbSet.Where(where);
        }

    }
}
