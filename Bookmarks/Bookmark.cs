using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarks
{
    public class Bookmark
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
