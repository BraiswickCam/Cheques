using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

namespace Cheques
{
    public partial class Default : System.Web.UI.Page
    {
        public bool path1, path2, path3;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                banklistPathText.Text = ConfigurationManager.AppSettings["bankListPath"];
                bankchqPathText.Text = ConfigurationManager.AppSettings["bankChqListPath"];
                backupPathText.Text = ConfigurationManager.AppSettings["backupPath"];
                batchSplitText.Text = ConfigurationManager.AppSettings["batchSize"];
                CheckFiles();
            }
        }

        protected void saveSettings_Click(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings["bankListPath"] = banklistPathText.Text;
            ConfigurationManager.AppSettings["bankChqListPath"] = bankchqPathText.Text;
            ConfigurationManager.AppSettings["backupPath"] = backupPathText.Text;
            ConfigurationManager.AppSettings["batchSize"] = batchSplitText.Text;
            CheckFiles();
        }

        protected void CheckFiles()
        {
            path1 = File.Exists(ConfigurationManager.AppSettings["bankListPath"]);
            path2 = File.Exists(ConfigurationManager.AppSettings["bankChqListPath"]);
            path3 = Directory.Exists(ConfigurationManager.AppSettings["backupPath"]);
        }
    }
}