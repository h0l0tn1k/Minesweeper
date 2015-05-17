using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Minesweeper
{
    public class TextFileLogStorage : ILogStorage
    {
        /// <summary>
        /// Stores path of file to read/write
        /// </summary>
        private string path; 
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileName">path + filename of file to be read/write from/to</param>
        /// <exception cref="IsNullOrWhiteSpace">fileName can not be null</exception>
        public TextFileLogStorage(string fileName)
        {
            if (String.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException("Filename can not be null or empty!");

            path = fileName;
        }

        public string Load()
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("File could not be read:");
                Console.WriteLine(e.Message);
            }

            return null;
        }

        public void Save(string content)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                using (StreamWriter fs = new StreamWriter(path, false))
                {
                    fs.Write(content);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file \"" + path + "\" could not be written into:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
