using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Assignment_UWP.Entity
{
    class NoteFile
    {

        public string Name { get; set; }
        public string Content { get; set; }
        public static object Text { get; internal set; }
    

        public NoteFile(string name, string content)
        {
            Name = name;
            Content = content;
        }
    }
}
