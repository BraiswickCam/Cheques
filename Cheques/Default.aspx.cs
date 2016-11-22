using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Cheques
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                banklistPathText.Text = ConfigurationManager.AppSettings["bankListPath"];
                bankchqPathText.Text = ConfigurationManager.AppSettings["bankChqListPath"];
            }
        }

        protected void saveSettings_Click(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings["bankListPath"] = banklistPathText.Text;
            ConfigurationManager.AppSettings["bankChqListPath"] = bankchqPathText.Text;
        }
    }
}