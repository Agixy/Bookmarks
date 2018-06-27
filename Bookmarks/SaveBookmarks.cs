using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Bookmarks
{
    class SaveBookmarks
    {           
        public void SerializeBookmarks(List<Bookmark> list, string pathToFile)
        {
            var bookmarkFile = new JavaScriptSerializer().Serialize(list);
            Directory.CreateDirectory(Path.GetDirectoryName(pathToFile));
            File.WriteAllText(pathToFile, bookmarkFile);
        }

    }    
}
