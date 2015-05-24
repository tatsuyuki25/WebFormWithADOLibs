using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Configuration;
using System.Reflection;
namespace MVCwithADO.NET.Models.DALs
{
    public class ProductDal
    {
        public EnumerableRowCollection<DataRow> Get()
        {
            string assemblyPath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(assemblyPath.Replace("%20"," "));
            ConnectionStringsSection connectStrings = config.GetSection("connectionStrings") as ConnectionStringsSection;
            SqlConnection conn = new SqlConnection(connectStrings.ConnectionStrings["Northwind"].ConnectionString.ToString());
            string sql = "select * from Products";
            DataSet ds = new DataSet();
            using (conn)
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(ds, "Products");
            }
            EnumerableRowCollection<DataRow> table = ds.Tables[0].AsEnumerable();
            return table;
        }
    }
}