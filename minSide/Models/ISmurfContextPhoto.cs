using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minSide.Models {
    public interface ISmurfContextPhoto {
        
        IQueryable<Photo> Photos { get; }
        IQueryable<PhotoComment> PhotoCommentsBil { get; }
        Photo FindPhotoById(int ID);
        int SaveChanges();
        T Add<T>(T entity) where T : class;
        T Delete<T>(T entity) where T : class;
    }
}
