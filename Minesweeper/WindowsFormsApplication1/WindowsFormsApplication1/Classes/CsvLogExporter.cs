using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    /// <summary>
    /// CsvLogExporter class for exporting List of T objects into file in csv format
    /// </summary>
    /// <typeparam name="T">Type of objects</typeparam>
    public class CsvLogExporter<T> : ILogExporter<T> where T : class, new()
    {
        /// <summary>
        /// Output file
        /// </summary>
        private ILogStorage logStorage;
        /// <summary>
        /// Names of properties
        /// </summary>
        private string[] columnMappings;
        /// <summary>
        /// determines if file has to have header
        /// </summary>
        private bool hasHeaderRow;
        /// <summary>
        /// character that spreads columns
        /// </summary>
        private char columnDelimiter;
        /// <summary>
        /// character that strings starts and ends with
        /// </summary>
        private char textQualifier;



        /// <summary>
        /// Consturctor
        /// </summary>
        /// <param name="logStorage">Output file</param>
        /// <param name="columnMappings">Names of properties</param>
        /// <param name="hasHeaderRow">determines if file has to have header</param>
        /// <param name="columnDelimiter">character that spreads columns</param>
        /// <param name="textQualifier">character that strings starts and ends with</param>
        /// <exception cref="ArgumentNullException">logStorage can not be null</exception>
        /// <exception cref="ArgumentException">columnMappings contains not recognized properties</exception>
        public CsvLogExporter(ILogStorage logStorage, string[] columnMappings, bool hasHeaderRow, char columnDelimiter, char textQualifier)
        {
            if (logStorage == null)
            {
                throw new ArgumentNullException("logStorage is null");
            }
            T obj = new T();
            for (int i = 0; i < columnMappings.Length; i++)
            {
                PropertyInfo pInfo = obj.GetType().GetProperty(columnMappings[i]);
                if (pInfo == null)
                    throw new ArgumentException("columnMappings contains not recognized property \"" + columnMappings[i] + "\"!");
            }
            this.logStorage = logStorage;
            this.columnMappings = columnMappings;
            this.hasHeaderRow = hasHeaderRow;
            this.columnDelimiter = columnDelimiter;
            this.textQualifier = textQualifier;
        }


        /// <summary>
        /// Exports data to file
        /// </summary>
        /// <param name="data">Data to be exported</param>
        public void Export(List<T> data)
        {
            ///   CHECK COLUMN MAPPINGS FOR NECCESSARY PROPERTIES IN T CLASS
            
            if (data == null)
            {
                Console.WriteLine("No data to export!");
                return;
            }
            string result = "";

            if (hasHeaderRow)
            {
                foreach (string item in columnMappings)
                {
                    result += item + columnDelimiter.ToString();
                }
                result = result.Remove(result.Length - 1);
                result += "\r\n";
            }

            foreach (T item in data)
            {
                for (int i = 0; i < columnMappings.Length; i++)
                {
                    try
                    {
                        PropertyInfo propertyInfo = item.GetType().GetProperty(columnMappings[i]);

                        if (propertyInfo.PropertyType == typeof(string))
                        {
                            result += textQualifier.ToString() + propertyInfo.GetValue(item).ToString() + textQualifier.ToString();
                        }
                        else if(propertyInfo.PropertyType == typeof(DateTime))
                        {
                            result += ((DateTime)propertyInfo.GetValue(item)).ToString(CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            result += propertyInfo.GetValue(item);
                        }
                        result += columnDelimiter.ToString();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Ehm, some mistake occured ---->here<----: " + e.Message);
                    }
                }
                result = result.Remove(result.Length - 1);
                result += "\r\n";
            }
            result = result.Remove(result.Length - 1);

            logStorage.Save(result);
        }
    }
}
