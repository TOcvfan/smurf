using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minSide.Models {
    interface ISmurfContextBil {
        
        IQueryable<Photo> Photos { get; }
        IQueryable<PhotoCommentBil> PhotoCommentsBil { get; }
        Photo FindPhotoById(int ID);
        int SaveChanges();
        T Add<T>(T entity) where T : class;
        T Delete<T>(T entity) where T : class;
    }
}
