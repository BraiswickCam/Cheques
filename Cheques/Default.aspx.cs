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
            if (banklistPathText.Text.ToLower().Contains("banklist")) { ConfigurationManager.AppSettings["bankListPath"] = banklistPathText.Text; }
            else { banklistPathText.Text = ConfigurationManager.AppSettings["bankListPath"]; }

            if (bankchqPathText.Text.ToLower().Contains("bankchq")) { ConfigurationManager.AppSettings["bankChqListPath"] = bankchqPathText.Text; }
            else { bankchqPathText.Text = ConfigurationManager.AppSettings["bankChqListPath"]; }

            ConfigurationManager.AppSettings["backupPath"] = backupPathText.Text;
            ConfigurationManager.AppSettings["batchSize"] = batchSplitText.Text;
            CheckFiles();
        }

        protected void finDayButton_Click(object sender, EventArgs e)
        {
            CheckFiles();
            FinalizeDay();
            CheckFiles();
        }

        protected void CheckFiles()
        {
            path1 = File.Exists(ConfigurationManager.AppSettings["bankListPath"]);
            path2 = File.Exists(ConfigurationManager.AppSettings["bankChqListPath"]);
            path3 = Directory.Exists(ConfigurationManager.AppSettings["backupPath"]);
        }

        protected bool FinalizeDay()
        {
            if (path1 == false || path2 == false || path3 == false)
            {
                finfailalert.Attributes["class"] = "alert alert-danger alert-dismissible";
                return false;
            }
            else
            {
                string bankListPath = ConfigurationManager.AppSettings["bankListPath"];
                string bankChqListPath = ConfigurationManager.AppSettings["bankChqListPath"];
                string backupDir = String.Format("{0}\\{1}_FINAL", ConfigurationManager.AppSettings["backupPath"], DateTime.Now.ToString("yyyyMMdd_HHmmss"));

                try
                {
                    Directory.CreateDirectory(backupDir);
                }
                catch (Exception e)
                {
                    finfailalert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    finfailalert.InnerHtml += String.Format(" {0}", e.Message);
                    return false;
                }

                try
                {
                    File.Copy(bankListPath, String.Format("{0}\\BANKLIST.TXT", backupDir));
                    File.Copy(bankChqListPath, String.Format("{0}\\BANKCHQ.TXT", backupDir));
                }
                catch (Exception e)
                {
                    finfailalert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    finfailalert.InnerHtml += String.Format(" Unable to backup txt files. {0}", e.Message);
                    return false;
                }

                try
                {
                    File.WriteAllText(bankListPath, "");
                    File.WriteAllText(bankChqListPath, "");
                }
                catch (Exception e)
                {
                    finfailalert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    finfailalert.InnerHtml += String.Format(" Unable to clear original txt files. {0}", e.Message);
                    return false;
                }

                finsuccessalert.Attributes["class"] = "alert alert-success alert-dismissible";

                return true;
            }
        }
    }
}