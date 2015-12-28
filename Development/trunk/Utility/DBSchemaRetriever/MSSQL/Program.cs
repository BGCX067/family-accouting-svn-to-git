using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.Utility.DBSchemaRetriever.MSSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Sql2005Scripter runner = new Sql2005Scripter(Environment.CommandLine, Console.Out);
            runner.Run();
        }
    }
}
