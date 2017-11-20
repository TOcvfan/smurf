using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minSide.Models {
    interface ISmurfGuestBookContext {
        IQueryable<GuestBook> GuestBookNotes { get; }
        int SaveChanges();
        T Add<T>(T entity) where T : class;
    }
}
