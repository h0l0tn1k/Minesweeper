using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Minesweeper
{
    /// <summary>
    /// CsvLogImporter class, parses csv file into class T
    /// </summary>
    /// <typeparam name="T">Type of class to store data into</typeparam>
    public class CsvLogImporter<T> : ILogImporter<T> where T : class, new()
    {
        /// <summary>
        /// File to read from
        /// </summary>
        private ILogStorage logStorage;
        /// <summary>
        /// Properties of class T
        /// </summary>
        private string[] properties;
        /// <summary>
        /// determines if file has header
        /// </summary>
        private bool hasHeaderRow;
        /// <summary>
        /// contains character that splits columns
        /// </summary>
        private char columnDelimiter;
        /// <summary>
        /// Contains character that strings starts and ends with
        /// </summary>
        private char textQualifier;

        /// <summary>
        /// Constructor of CsvLogImporter class
        /// </summary>
        /// <param name="logStorage">File object to read data from</param>
        /// <param name="columnMappings">Names of Properties for class T</param>
        /// <param name="hasHeaderRow">determines if file has header</param>
        /// <param name="columnDelimiter">single character which spreads columns</param>
        /// <param name="textQualifier">character with which strings starts & ends</param>
        /// <exception cref="ArgumentNullException">logStorage can not be null</exception>
        /// <exception cref="ArgumentNullException">columnMappings can not be null</exception>
        /// <exception cref="ArgumentException">columnMappings contains not recognized properties</exception>
        public CsvLogImporter(ILogStorage logStorage, string[] columnMappings, bool hasHeaderRow, char columnDelimiter, char textQualifier)
        {
            if (logStorage == null)
            {
                throw new ArgumentNullException("logStorage is null!");
            }
            if (columnMappings == null)
            {
                throw new ArgumentNullException("columnMappings is null!");
            }

            T obj = new T();
            for (int i = 0; i < columnMappings.Length; i++)
            {
                PropertyInfo pInfo = obj.GetType().GetProperty(columnMappings[i]);
                if (pInfo == null)
                    throw new ArgumentException("columnMappings contains not recognized property \"" + columnMappings[i] + "\"!");
            }
            this.logStorage = logStorage;
            this.properties = columnMappings;
            this.hasHeaderRow = hasHeaderRow;
            this.columnDelimiter = columnDelimiter;
            this.textQualifier = textQualifier;
        }

        /// <summary>
        /// imports data from file
        /// </summary>
        /// <returns>List of data</returns>
        public List<T> Import()
        {
            List<T> values = new List<T>();
            string fileContent = logStorage.Load();
            string[] lines = Regex.Split(fileContent, "\r\n");
            int i = 0;

            if (String.IsNullOrWhiteSpace(fileContent))
            {
                return null;
            }
            if (hasHeaderRow)
            {
                i++;
            }

            for ( ; i < lines.Length; i++)
            {
                ///Values array for each line
                string[] columnOfGivenLine = Regex.Split(lines[i], columnDelimiter.ToString());
                int l = 0;
                T obj = new T();
                bool create = true;


                foreach (string item in columnOfGivenLine)
                {
                    if (String.IsNullOrEmpty(item)) {
                        create = false;
                        break;
                    }
                    try
                    {
                        PropertyInfo propertyInfo = obj.GetType().GetProperty(properties[l]);
                        if (propertyInfo.PropertyType == typeof(string))
                        {
                            ///ERASING TEXT QUALIFIER FROM GIVEN STRING
                            string result = item.Trim(textQualifier);
                            propertyInfo.SetValue(obj, Convert.ChangeType(result, propertyInfo.PropertyType), null);
                        }
                        else if (propertyInfo.PropertyType == typeof(DateTime))
                        {
                            propertyInfo.SetValue(obj, Convert.ChangeType(item, propertyInfo.PropertyType, CultureInfo.InvariantCulture), null);
                        }
                        else
                        {
                            propertyInfo.SetValue(obj, Convert.ChangeType(item, propertyInfo.PropertyType), null);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Unable to convert rest of the file : " + ex.Message);
                        break;
                    }

                    l++;
                }
                if(create)
                    values.Add(obj);
            }

            return values;
        }
    }
}
