using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minSide.Models {
    interface ISmurfContext {
        IQueryable<Photo> Photos { get; }
        IQueryable<PhotoComment> PhotoComments { get; }
        IQueryable<PageComment> PageComments { get; }
        int SaveChanges();
        T Add<T>(T entity) where T : class;
        T Delete<T>(T entity) where T : class;
    }
}
