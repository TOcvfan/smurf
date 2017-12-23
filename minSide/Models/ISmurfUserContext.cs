using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minSide.Models {
    public interface ISmurfUserContext {
        IQueryable<User> UserInfo { get; }
        int SaveChanges();
        T Add<T>(T entity) where T : class;
    }
}
