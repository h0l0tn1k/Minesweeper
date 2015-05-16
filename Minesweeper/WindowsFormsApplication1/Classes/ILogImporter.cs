using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    /// <summary>
    /// Interface for importing various datatypes
    /// </summary>
    /// <typeparam name="T">Generic class for storing parsed data</typeparam>
    public interface ILogImporter<T> where T : class, new()
    {
        /// <summary>
        /// Parses string into T class
        /// </summary>
        /// <returns>List of classes T</returns>
        List<T> Import();
    }
}
