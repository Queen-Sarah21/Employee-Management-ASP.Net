using Lab1_ASPNetConnectedMode.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Lab1_ASPNetConnectedMode.GUI
{
    public partial class WebFormTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonConnectDB_Click(object sender, EventArgs e)
        {
            SqlConnection connDB = UtilityDB.GetDBConnection();
            MessageBox.Show(Convert.ToString(connDB.State), "Database Connection");
            //lblState.Text = "Database Connection State: " + connDB.State.ToString();

        }
    }
}