using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
      class FileHandler
      {

            public FileHandler() { }

            public List<string> ReadFile(string filePath)
            {

                  return File.ReadAllLines(filePath).ToList<string>();

            }
      }
}
