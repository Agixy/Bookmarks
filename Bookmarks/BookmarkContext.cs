using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarks
{
    class BookmarkContext : DbContext
    {
        public BookmarkContext() : base("name=Bookmarks")
        {
        }

        public DbSet<Bookmark> MyBookmarks { get; set; }

    }
}
