using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class PreDefine
    {
        public const string ConnectionStatement = "Persist Security Info=False;Initial Catalog={0};Data Source={1};User ID={2};Password={3}";

        public const string PhysicalPath = @"C:\TESTCASE";

        public const string PhysicalMDFPath = @"C:\TESTCASE\TestCase_Data.mdf";
        
        public const string PhysicalLDFPath = @"C:\TESTCASE\TestCase_Log.ldf";

        public static readonly string[] ADOPass = { "sodent", "2002", "ecnad", "ghd189046", "osstem" };
    }
}
