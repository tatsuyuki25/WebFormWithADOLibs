using MVCwithADO.NET.Models.DALs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormWithADOLibs
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductDal p = new ProductDal();
            IEnumerable<DataRow> table = p.Get();
            GridView1.DataSource = table.CopyToDataTable();
            GridView1.DataBind();
        }
    }
}