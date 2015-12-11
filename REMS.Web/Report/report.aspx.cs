using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections;
using System.Globalization;
using Microsoft.Reporting.WebForms;

namespace REMS.Web.Report
{
    public partial class report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnVieReport_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            SqlCommand cmd;
            cmd = new SqlCommand("select * from Payslip where PayslipID=2", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            ReportDataSource datasource = new ReportDataSource();
            datasource.Name = "DataSet2";//SynoProjectDBDataSet1
            datasource.Value = ds.Tables[0];
            //ReportParameter name = new ReportParameter("Name", "Chain1");
            //ReportParameter AgentID = new ReportParameter("AgentID", "Dev Nagar");
            //ReportParameter RankID = new ReportParameter("Rank", "SATNA (M.P.)");
            //ReportParameter SnAgentID = new ReportParameter("SnAgentID", "SATNA (M.P.)");
            //ReportParameter CSCCode = new ReportParameter("CSC", "SATNA (M.P.)");
            //ReportParameter DOJ = new ReportParameter("DOJ", "");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("SalarySlip.rdlc");
            ReportViewer1.LocalReport.ReportEmbeddedResource = "SalarySlip.rdlc";
            ReportViewer1.LocalReport.DataSources.Add(datasource);
        }


    }
}