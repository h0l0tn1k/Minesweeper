using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    /// <summary>
    /// Interface for Exporting logs
    /// </summary>
    /// <typeparam name="T">Type of input objects</typeparam>
    public interface ILogExporter<T> where T : class, new()
    {
        /// <summary>
        /// Exports List of T objects into file in json format
        /// </summary>
        /// <param name="data">list of objects T</param>
        void Export(List<T> data);
    }
}
