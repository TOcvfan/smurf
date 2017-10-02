using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace minSide.Models {
    public class SmurfContext : DbContext, ISmurfContext {
        public DbSet<Photo> Photos { get; set; }
        public DbSet<PhotoComment> PhotoComments { get; set; }
        public DbSet<PageComment> PageComments { get; set; }

        IQueryable<PageComment> ISmurfContext.PageComments {
            get { return PageComments; }
        }

        IQueryable<Photo> ISmurfContext.Photos {
            get { return Photos; }
        }

        IQueryable<PhotoComment> ISmurfContext.PhotoComments {
            get { return PhotoComments; }
        }

        public T Add<T>(T entity) where T : class {
            throw new NotImplementedException();
        }

        public T Delete<T>(T entity) where T : class {
            throw new NotImplementedException();
        }

        
    }
}