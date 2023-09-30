using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJ2_Save_Editor
{
    public class Utils
    {
        public static void Patch(string NewText, int LineToEdit,string path)
        {
            string[] arrLine = System.IO.File.ReadAllLines(path);
            arrLine[LineToEdit - 1] = NewText;
            System.IO.File.WriteAllLines(path, arrLine);
        }
    }
}
