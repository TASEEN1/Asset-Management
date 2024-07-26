using Microsoft.AspNetCore.Hosting;
using Microsoft.Reporting.NETCore;
using PMS_BLL.Interfaces.Manager.OrderMgt;
using PMS_BLL.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_DAL.Implementation.Manager.OrderMgt
{
    public class OrderReportManager : IOrderReportManager
    {
        private readonly Dg_SqlCommon _SqlCommon;
        private readonly SqlConnection _specfo_conn;
        private readonly SqlConnection _dg_Asst_Mgt;
        private readonly SqlConnection _SpecFoInventory;
        private readonly SqlConnection _dg_Oder_Mgt;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public OrderReportManager(Dg_SqlCommon sqlCommon, IWebHostEnvironment webHostEnvironment)
        {
            _SqlCommon = sqlCommon;
            _webHostEnvironment = webHostEnvironment;
            _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
            _dg_Asst_Mgt = new SqlConnection(Dg_Getway.dg_Asst_Mgt);
            _SpecFoInventory = new SqlConnection(Dg_Getway.SpecFoInventory);
            _dg_Oder_Mgt = new SqlConnection(Dg_Getway.dg_Oder_Mgt);

        }


        public byte[] OrderReceivedReport (int comID , string UserName , string reportType,int? customer ,string? style_No, DateTime FromDate , DateTime ToDate)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("dg_order_receiving_Rpt ");
            stringBuilder.Append(customer != null ? customer: "NULL");
            stringBuilder.Append(", '" + (style_No != null ? style_No : "NULL"));
            stringBuilder.Append("', '");
            stringBuilder.Append(FromDate.ToString("yyyy-MM-dd") + "', '");
            stringBuilder.Append(ToDate.ToString("yyyy-MM-dd"));
            stringBuilder.Append("' ");

            string stateQu = stringBuilder.ToString();
            var tbldata = new DataTable[]
            {
                 
                 _SqlCommon.get_InformationDataTable(stateQu,_dg_Oder_Mgt)
            };
            var strSetName = new string[]
            {
                "OrdDataSet"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Order_Mgt_Report\\OrderWiseRpt.rdlc";
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Order Receive Report"),
            new ReportParameter("PrintUser",  "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;


        }


        public byte[] ProformaInvoiceReport(int comID, string UserName, string reportType, int? pi_issued_ref_no, string? pi_number)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("dg_proforma_invoice_Rpt ");
            stringBuilder.Append(pi_issued_ref_no != null ? pi_issued_ref_no : "NULL");
            stringBuilder.Append(", '" + (pi_number != null ? pi_number : "NULL"));
            stringBuilder.Append("' ");

            string stateQu = stringBuilder.ToString();
            var tbldata = new DataTable[]
            {

                 _SqlCommon.get_InformationDataTable(stateQu,_dg_Oder_Mgt)
            };
            var strSetName = new string[]
            {
                "OrdDataSet"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Order_Mgt_Report\\Proforma_Invoice.rdlc";
            string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("UserSignPath",imgERP),
            new ReportParameter("Title", "Proforma Invoice"),
            new ReportParameter("PrintUser",  "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;


        }

        //---------------------------------------------- TEST Code---------------------------------------------

        //public byte[] ProformaInvoiceReport(int comID, string UserName, string reportType, int? pi_issued_ref_no, string? pi_number)
        //{
        //    DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
        //    string ComName = dt.Rows[0]["cCmpName"].ToString();
        //    string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
        //    string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
        //    DataTable dt2 = _SqlCommon.get_InformationDataTable("select cUserFullname, signtr from SpecFo.dbo.Smt_Users where cUserName = (select pi_checkedBy_user from dg_pi_issued where pi_issued_ref_no ='" + pi_issued_ref_no + "'", _dg_Oder_Mgt);
        //    string UserSignPath1 = dt.Rows[0]["UserSignPath1"].ToString();
        //    StringBuilder stringBuilder = new StringBuilder();
        //    stringBuilder.Append("dg_proforma_invoice_Rpt ");
        //    stringBuilder.Append(pi_issued_ref_no != null ? pi_issued_ref_no : "NULL");
        //    stringBuilder.Append(", '" + (pi_number != null ? pi_number : "NULL"));
        //    stringBuilder.Append("' ");

        //    string stateQu = stringBuilder.ToString();
        //    var tbldata = new DataTable[]
        //    {

        //         _SqlCommon.get_InformationDataTable(stateQu,_dg_Oder_Mgt)
        //    };
        //    var strSetName = new string[]
        //    {
        //        "OrdDataSet"
        //    };
        //    string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Order_Mgt_Report\\Proforma_Invoice.rdlc";
        //    string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign").AbsoluteUri;
        //    ReportParameterCollection reportParameters = new ReportParameterCollection
        //    {
        //    new ReportParameter("Company",ComName),
        //    new ReportParameter("Add1", cAdd1),
        //    new ReportParameter("Title", "Proforma Invoice"),
        //    new ReportParameter("UserSignPath1",UserSignPath1),
        //    new ReportParameter("PrintUser",  "" + UserName + "")
        //    };
        //    byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
        //    return reportBytes;


        //}



        //Common Report Code
        private byte[] GenerateReport(DataTable dataTable, string datasetName, string rdlcFilePath, string reportType, ReportParameterCollection reportParameters = null)
        {
            LocalReport localReport = new LocalReport();
            ReportDataSource reportDataSource = new ReportDataSource(datasetName, dataTable);
            localReport.ReportPath = rdlcFilePath;
            localReport.EnableExternalImages = true;
            localReport.DataSources.Clear();
            localReport.DataSources.Add(reportDataSource);
            if (reportParameters != null)
            {
                localReport.SetParameters(reportParameters);
            }
            localReport.Refresh();
            byte[] reportBytes;
            switch (reportType.ToUpper())
            {
                case "PDF":
                    reportBytes = localReport.Render("PDF");
                    break;
                case "EXCEL":
                    reportBytes = localReport.Render("EXCELOPENXML");
                    break;
                case "WORD":
                    reportBytes = localReport.Render("WORDOPENXML");
                    break;
                default:
                    throw new ArgumentException("Unsupported report type");
            }
            return reportBytes;
        }
        private byte[] GenerateReport(DataTable[] dataTable, string[] datasetName, string rdlcFilePath, string reportType, ReportParameterCollection reportParameters = null)
        {
            LocalReport localReport = new LocalReport();
            localReport.DataSources.Clear();
            for (int i = 0; i < dataTable.Length; i++)
            {
                string dataset = datasetName[i];
                var dt = dataTable[i];
                ReportDataSource reportDataSource = new ReportDataSource(dataset, dt);
                localReport.DataSources.Add(reportDataSource);
            }
            localReport.ReportPath = rdlcFilePath;
            localReport.EnableExternalImages = true;
            if (reportParameters != null)
            {
                localReport.SetParameters(reportParameters);
            }
            localReport.Refresh();
            byte[] reportBytes;
            switch (reportType.ToUpper())
            {
                case "PDF":
                    reportBytes = localReport.Render("PDF");
                    break;
                case "EXCEL":
                    reportBytes = localReport.Render("EXCELOPENXML");
                    break;
                case "WORD":
                    reportBytes = localReport.Render("WORDOPENXML");
                    break;
                default:
                    throw new ArgumentException("Unsupported report type");
            }
            return reportBytes;
        }



    }
}
