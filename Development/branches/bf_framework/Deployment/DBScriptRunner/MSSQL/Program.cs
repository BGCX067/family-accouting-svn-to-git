using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.FamilyAccounting.Deployment.DBScriptRunner.MSSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlCmdRunner runner = new SqlCmdRunner(Environment.CommandLine);
            Environment.ExitCode = runner.Run();
        }
    }
}
