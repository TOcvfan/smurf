using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace minSide.Models {
    public class SmurfContext : DbContext, ISmurfContext {
        public DbSet<Photo> Photos { get; set; }
        public DbSet<PhotoComment> Comments { get; set; }

        IQueryable<Photo> ISmurfContext.Photos {
            get { return Photos; }
        }
        IQueryable<PhotoComment> ISmurfContext.Comments {
            get { return Comments; }
        }
        public T Add<T>(T entity) where T : class {
            throw new NotImplementedException();
        }

        public T Delete<T>(T entity) where T : class {
            throw new NotImplementedException();
        }

        public PhotoComment FindCommentById(int ID) {
            throw new NotImplementedException();
        }

        public Photo FindPhotoById(int ID) {
            throw new NotImplementedException();
        }

        public Photo FindPhotoByTitle(string Title) {
            throw new NotImplementedException();
        }
    }
}