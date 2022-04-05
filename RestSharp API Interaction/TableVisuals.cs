using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharp_API_Interaction
{
    internal class TableVisuals
    {
        public static void ShowTable<T>(List<T>tableData, string tableName) where T : class
        {
            Console.Clear();
            ConsoleTableBuilder.From(tableData).WithColumn(tableName).ExportAndWriteLine();
        }
    }
}
