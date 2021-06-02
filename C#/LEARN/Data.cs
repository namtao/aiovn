using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LEARN
{
    class Data
    {
        public SqlConnection GetConnect()
        {
            return new SqlConnection(@"Data Source=.;Initial Catalog=Learn;Integrated Security=True");
        }
    }
}
