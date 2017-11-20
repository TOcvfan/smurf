using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace minSide.Models {
    public class SmurfContext : DbContext, ISmurfContext, ISmurfGuestBookContext, ISmurfUserContext {
        public DbSet<Photo> Photos { get; set; }
        public DbSet<PhotoComment> PhotoComments { get; set; }
        public DbSet<GuestBook> GuestBookNotes { get; set; }
        public DbSet<User> UserInfo { get; set; }

        IQueryable<User> ISmurfUserContext.UserInfo {
            get { return UserInfo; }
        }

        IQueryable<GuestBook> ISmurfGuestBookContext.GuestBookNotes {
            get { return GuestBookNotes; }
        }

        IQueryable<Photo> ISmurfContext.Photos {
            get { return Photos; }
        }

        IQueryable<PhotoComment> ISmurfContext.PhotoComments {
            get { return PhotoComments; }
        }
        
        public T Add<T>(T entity) where T : class {
            return Set<T>().Add(entity);
        }

        public T Delete<T>(T entity) where T : class {
            return Set<T>().Remove(entity);
        }

        public Photo FindPhotoById(int ID) {
            return Set<Photo>().Find(ID);
        }
    }
}