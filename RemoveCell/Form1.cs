using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using System.Xml;
using System.Net;
using System.IO;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;

namespace RemoveCell
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            String currUser = System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName;//Get logged in users' name, reqires network connection
            this.Text +=  currUser; 
            this.cmbEnviroList.SelectedIndex = 0;

            var webRequest = WebRequest.Create(@"http:///UserData.txt"); //changed for security

            string[] cellNum;

            try
            {
                //this whole block here grabs the data file from sharepoint
                webRequest.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials; //else we get 401 unauthorized
                using (var response = webRequest.GetResponse())
                using (var content = response.GetResponseStream())
                using (var reader = new StreamReader(content))
                {
                    var strContent = reader.ReadToEnd();
                    cellNum = strContent.Split(',');
                }

                //forloop included in try because there wont be a length if the file wasn't assible
                for (int i = 0; i < cellNum.Length; i++)
                {
                    if (cellNum[i].Contains(currUser))
                    {
                        txbCellNum.Text = cellNum[i].Substring(cellNum[i].LastIndexOf('+'));
                    }
                }
            }
            catch (Exception)
            {
                //This catch is empty because the program will still work if we can't preload a number
            }
            
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string selection = cmbEnviroList.Text;
            string dbDetails = "";
            bool isCanceled = false;


            //connection strings removed for security
            switch (selection)
            {
                case "Lab":

                    dbDetails = "";//works

                    break;

                case "Dev":


                    dbDetails = ""; //works

                    break;

                case "QA":
                    dbDetails = ";";//get details

                    break;

                case "Pre-Prod":

                   dbDetails = "";//works

                    break;

                case "Prod":

                    DialogResult shouldProceed = MessageBox.Show("Purge cell number " + txbCellNum.Text + " from PRODUCTION?", "Warning", MessageBoxButtons.YesNo);
                    if (shouldProceed == DialogResult.Yes)
                    {
                        dbDetails = "";
                    }
                    else {
                        isCanceled = true;
                    }

                    break;
            }

            try
            {
                if (isCanceled) {
                    return;
                }
                DB_Call(dbDetails, NumberCleaner(txbCellNum.Text));
            }
            catch (Exception ex){
                lblInfo.Text = "";

                MessageBox.Show("Application unable to connect.\n\n 1. Please check your network connection.\n" +
                    "2. A database password may have changed, please contact an IAM Developer.","Something Went Wrong!");

                
            }
        }

        

        protected void DB_Call(string connStr, string cellNumber) {
            OracleConnection conn = new OracleConnection(connStr);

            lblInfo.Text = "Connecting...";

            conn.Open();

            lblInfo.Text = "Connected";


            // security risks have been removed
            string sql = "UPDATE [table] SET [field] = ''"
                + ", [field] = ''"
                + ", [field] = ''"
                + "  [field] = '" + cellNumber+"'";

            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.CommandType = CommandType.Text;

            try
            {
                OracleDataReader dr = cmd.ExecuteReader();
                dr.Read();

                MessageBox.Show("Operation successful", "Notification");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }



            conn.Close();

            lblInfo.Text = "Connection closed";
        }

        // formats the cell number correctly for the sql statement, so +27123456789, 0123456789, 012 345 6789 aall work
        protected string NumberCleaner(string cellNum) {

            char[] temp = cellNum.ToCharArray();

            cellNum = "";

            for(int i = 0; i < temp.Length; i++)
            {
                if (!temp[i].Equals(' ')) {
                    cellNum = cellNum + temp[i];
                }
            }

            cellNum = cellNum.Trim();

            if (cellNum.ElementAt(0).Equals('0')) {
                cellNum = cellNum.Remove(0, 1);
                cellNum = "+27" + cellNum;
            }

            cellNum = cellNum.Trim();

            return cellNum;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblInfo_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
