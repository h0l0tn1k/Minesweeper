using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    /// <summary>
    /// Stores path and filename
    /// Has functions to Load and Save to file
    /// </summary>
    public interface ILogStorage
    {
        /// <summary>
        /// Loads contain from file given in constructor
        /// </summary>
        /// <returns>contain of file</returns>
        string Load();
        /// <summary>
        /// Saves content from argument to file specified in constructor
        /// </summary>
        /// <param name="content"></param>
        void Save(string content);
    }
}
