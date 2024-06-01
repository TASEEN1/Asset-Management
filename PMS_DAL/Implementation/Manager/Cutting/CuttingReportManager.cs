using Microsoft.Reporting.NETCore;
using System.Data.SqlClient;
using PMS_BLL.Utility;
using System.Data;
using Microsoft.AspNetCore.Hosting;
using PMS_BLL.Interfaces.Manager.Cutting;

namespace PMS_DAL.Implementation.Manager.Cutting
{
    public class CuttingReportManager : ICuttingReportManager
    {
        private readonly Dg_SqlCommon _SqlCommon;
        private readonly SqlConnection _dg_pms_conn;
        private readonly SqlConnection _specfo_conn;
        private readonly SqlConnection _dg_barcode_conn;
        private readonly SqlConnection _dg_smartCode_conn;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CuttingReportManager(Dg_SqlCommon sqlCommon, IWebHostEnvironment webHostEnvironment)
        {
            _SqlCommon = sqlCommon;
            _webHostEnvironment = webHostEnvironment;
            _dg_pms_conn = new SqlConnection(Dg_Getway.PmsCon);
            _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
            //_dg_barcode_conn = new SqlConnection(Dg_Getway.dg_barcode);
            //_dg_smartCode_conn = new SqlConnection(Dg_Getway.dg_smart_code);
        }

        // Cutting Report Cut, Lay and Style wise
        public byte[] LayWiseReport(string reportType, int comID, int style, int cut, int lay, string UserName)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                _SqlCommon.get_InformationDataTable("Mr_LayWise_Rpt '"+ style + "','"+cut+"','"+lay+"'", _dg_pms_conn),
              
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Cutting_Report\\dg_LayWise_Rpt.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Lay Wise Cutting Report"),
            new ReportParameter("PrintUser",  "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }

        // Cutting Report Style, PO and Country wise
        public byte[] Cut_Style_CountryReport(string reportType, int comID, int style, int po, int country, string UserName)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                _SqlCommon.get_InformationDataTable("Mr_Style_PO_Col_Country_Rpt '"+ style + "','"+po+"','"+country+"'", _dg_pms_conn),
               
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Cutting_Report\\dg_Cut_Style_Country_Rpt.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Cutting Report- Country Wise"),
             new ReportParameter("PrintUser",  "" + UserName + "")

            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }

        // Daily Cutting Report

        public byte[] DailyCuttingReport(string reportType, int comID, DateTime CutDate, string UserName)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                _SqlCommon.get_InformationDataTable("Sp_Web_GetDailyCuttingProd '"+CutDate+"','"+ comID + "'", _dg_smartCode_conn),
          
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Cutting_Report\\dg_DailyCuttingRpt.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            //new ReportParameter("Factory",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Daily Cutting Report - Date: " + CutDate + ""),
            new ReportParameter("PrintUser",  "" + UserName + "")

            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }

        // Cutting Report Style, PO & LAY wise
        public byte[] StylePOLayWiseReport(string reportType, int comID, int style, string po, int lay, string UserName)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                _SqlCommon.get_InformationDataTable("Mr_Lay_PO_Wise_Rpt '"+ style + "','"+po+"','"+lay+"'", _dg_pms_conn),

            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Cutting_Report\\dg_LayWise_Rpt.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Lay Wise Cutting Report"),
            new ReportParameter("PrintUser",  "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }
        //  Cutting Summary D2D Report

        public byte[] CuttingSummaryD2DReport(string reportType, int comID, string fromdate, string todate, string UserName)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                _SqlCommon.get_InformationDataTable("Mr_Cutting_WIP_X_Factory_Rpt_New '"+fromdate+"','"+todate+"','"+ comID + "'", _dg_pms_conn),
           
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Cutting_Report\\dg_CutSummary_Cut_Date_D2D.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Factory",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Cutting Summary By-D2D - From Date: " + fromdate + ", To: " + todate + ""),
            new ReportParameter("PrintUser", "" + UserName + "")

            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }

        //  Style Wise Cutting To Input Report

        public byte[] StyleWiseCuttingToInputReport(string reportType, int comID, int styleID, string style, string UserName)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                _SqlCommon.get_InformationDataTable("Mr_Style_WiseOrdCutInput_Rpt '"+styleID+"'", _dg_barcode_conn),
            
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Cutting_Report\\dg_Style_Wise_Cut_To_Input_Qty.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),           
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Cutting Report Style Wise -Style No: " + style + ""),
            new ReportParameter("PrintUser", "" + UserName + "")

            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }
        //  Style and PO Wise Cutting To Input Report

        public byte[] StylePOWiseCuttingToInputReport(string reportType, int comID, int styleID, string style, string poID, string PO, string UserName)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                _SqlCommon.get_InformationDataTable("Mr_Style_PO_Wise_Cut_To_Input_Qty '"+styleID+"','"+poID+"'", _dg_barcode_conn),
              
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Cutting_Report\\dg_Style_PO_Wise_Cut_To_Input_Qty.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
           
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Style and PO No Wise Cut To Input Report- Style No:" + style + ", PO No:" + PO + ""),
            new ReportParameter("PrintUser", "" + UserName + "")

            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }

        //  Style and PO Wise Cutting To Input Report

        public byte[] StyleWiseClosingCuttingToInputReport(string reportType, int comID, int styleID, string style, string UserName)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                _SqlCommon.get_InformationDataTable("Mr_Cutting_Closing_Style_Wise_Report '"+styleID+"'", _dg_pms_conn),
                _SqlCommon.get_InformationDataTable("Mr_Cutting_Closing_Style_Line_Wise_Report '"+styleID+"'", _dg_pms_conn),
                     _SqlCommon.get_InformationDataTable("Mr_Cut_Fabrics_Closing_Rpt '"+styleID+"'", _dg_pms_conn),
            };
            var strSetName = new string[]
            {
                "DataSet1","DataSet2","DataSet3"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Cutting_Report\\dg_Cutting_Closing_Style_Wise_Report.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),        
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Style and PO No Wise Cut To Input Report- Style No:" + style + ""),
            new ReportParameter("PrintUser", "" + UserName + "")

            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }
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
