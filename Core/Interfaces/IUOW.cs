using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Core.Interfaces
{
    public interface IUOW : IDisposable
    {
        // Creating Generic Repo for storing multiple repos
        IGenericRepository<T> Repository<T>() where T: class;

        // Save Changes
        void SaveChanges();
    }
}
