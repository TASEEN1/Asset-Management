using Microsoft.AspNetCore.Hosting;
using PMS_BLL.Interfaces.Manager.AssetMaster;
using PMS_BLL.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Reporting.NETCore;
using System.Data;

namespace PMS_DAL.Implementation.Manager.Asset_Master
{
    public class AssetReportManager:IAssetReportManager
    {
        private readonly Dg_SqlCommon _SqlCommon;
        private readonly SqlConnection _specfo_conn;
        private readonly SqlConnection _dg_Asst_Mgt;
        private readonly SqlConnection _SpecFoInventory;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AssetReportManager(Dg_SqlCommon sqlCommon, IWebHostEnvironment webHostEnvironment)
        {
            _SqlCommon = sqlCommon;
            _webHostEnvironment = webHostEnvironment;
            _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
            _dg_Asst_Mgt = new SqlConnection(Dg_Getway.dg_Asst_Mgt);
            _SpecFoInventory = new SqlConnection(Dg_Getway.SpecFoInventory);
        }

        public byte[] AssetDetailsSummary(string reportType, int comID,  string UserName)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                 //_SqlCommon.get_InformationDataTable("Mr_Asset_Details_Summary_Rpt '"+ AsstCat + "','"+status+"','"+floor+"','"+line+"'",_dg_Asst_Mgt),
                 _SqlCommon.get_InformationDataTable("Mr_Asset_Details_Summary_Rpt '"+ comID + "'",_dg_Asst_Mgt)
               

            };
            var strSetName = new string[]
            {
                "AsstDetailSumm"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Asset_report\\AssetDetailsSummary.rdlc";
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Asset Details Summary Rport- Fectory:"  +ComName+""),
            new ReportParameter("PrintUser",  "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;


        }

        public byte[] AssetDetailsReport(string reportType, int comID,  string UserName)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                 //_SqlCommon.get_InformationDataTable("Mr_Asset_Details_Summary_Rpt '"+ AsstCat + "','"+status+"','"+floor+"','"+line+"'",_dg_Asst_Mgt),
                 _SqlCommon.get_InformationDataTable("Mr_Asset_Master_List_Info_Rpt '"+ comID + "'",_dg_Asst_Mgt)

            };
            var strSetName = new string[]
            {
                "Asset_DtailsDataset"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Asset_report\\Asset Details.rdlc";
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Asset Details Report- Fectory: "+ComName+""),
            new ReportParameter("PrintUser",  "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;


        }
        public byte[] AssetDetails_RepairReport(string reportType, int comID, string UserName)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                 
                 _SqlCommon.get_InformationDataTable("DG_Asset_Running_Repair_Details_Rpt '"+ comID + "'",_dg_Asst_Mgt)

            };
            var strSetName = new string[]
            {
                "AsstDataSet"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Asset_report\\Asset_Repair_ReportDatails.rdlc";
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Asset Details Repair Report- Fectory: "+ComName+""),
            new ReportParameter("PrintUser",  "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;


        }
        public byte[] AssetDetailsMaster_Report(string reportType, int comID, string UserName)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {

                 _SqlCommon.get_InformationDataTable("DG_AssetDetailsMaster_Rpt '"+ comID + "'",_dg_Asst_Mgt)

            };
            var strSetName = new string[]
            {
                "AsstDataSet"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Asset_report\\AssetDetailsMaster_Rpt.rdlc";
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Asset Details Report- Fectory: "+ComName+""),
            new ReportParameter("PrintUser",  "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;


        }

        //1 no report - Asset Management Report - M A Master List Rpt 
        public byte[] AssetManagementReport(string reportType, int comID, string UserName)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                _SqlCommon.get_InformationDataTable("Mr_Asset_Master_List_Rpt '" + comID + "'", _dg_Asst_Mgt),
                //_SqlCommon.get_InformationDataTable("Mr_Cutting_Closing_Style_Wise_Report '"+styleID+"'", _dg_pms_conn),
                //_SqlCommon.get_InformationDataTable("Mr_Cutting_Closing_Style_Line_Wise_Report '"+styleID+"'", _dg_pms_conn),
                //     _SqlCommon.get_InformationDataTable("Mr_Cut_Fabrics_Closing_Rpt '"+styleID+"'", _dg_pms_conn),
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Asset_Report\\AssetManagementReport.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Asset Details Report- Factory: " + ComName + ""),
            new ReportParameter("PrintUser", "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }

        //4 no report - Asset Summary Report - M A Summary Rpt 
        public byte[] AssetSummaryReport(string reportType, int comID, string UserName)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                _SqlCommon.get_InformationDataTable("Mr_Asset_Summary_Rpt '" + comID + "'", _dg_Asst_Mgt),
                //_SqlCommon.get_InformationDataTable("Mr_Cutting_Closing_Style_Wise_Report '"+styleID+"'", _dg_pms_conn),
                //_SqlCommon.get_InformationDataTable("Mr_Cutting_Closing_Style_Line_Wise_Report '"+styleID+"'", _dg_pms_conn),
                //     _SqlCommon.get_InformationDataTable("Mr_Cut_Fabrics_Closing_Rpt '"+styleID+"'", _dg_pms_conn),
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Asset_Report\\AssetSummaryReport.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Asset Summary Report- Factory: " + ComName + ""),
            new ReportParameter("PrintUser", "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }
        //9 no report - Rented asset details Report - DG_Rented_Asset_Details_Rpt
        public byte[] RentedAssetDetailsReport(string reportType, int comID, string UserName)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                _SqlCommon.get_InformationDataTable("DG_Rented_Asset_Details_Rpt '" + comID + "'", _dg_Asst_Mgt),
                //_SqlCommon.get_InformationDataTable("Mr_Cutting_Closing_Style_Wise_Report '"+styleID+"'", _dg_pms_conn),
                //_SqlCommon.get_InformationDataTable("Mr_Cutting_Closing_Style_Line_Wise_Report '"+styleID+"'", _dg_pms_conn),
                //     _SqlCommon.get_InformationDataTable("Mr_Cut_Fabrics_Closing_Rpt '"+styleID+"'", _dg_pms_conn),
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Asset_Report\\RentedAssetDetailsReport.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Rented Asset Details Report- Factory: " + ComName + ""),
            new ReportParameter("PrintUser", "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }

        //6 no report - internal fixed asset transfer Report - DG_Internal_Fixed_Asset_Transfer_Rpt
        public byte[] InternalFixedAssetTransferReport(string reportType, int comID, string UserName)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                _SqlCommon.get_InformationDataTable("DG_Internal_Fixed_Asset_Transfer_Rpt '" + comID + "'", _dg_Asst_Mgt),
                //_SqlCommon.get_InformationDataTable("Mr_Cutting_Closing_Style_Wise_Report '"+styleID+"'", _dg_pms_conn),
                //_SqlCommon.get_InformationDataTable("Mr_Cutting_Closing_Style_Line_Wise_Report '"+styleID+"'", _dg_pms_conn),
                //     _SqlCommon.get_InformationDataTable("Mr_Cut_Fabrics_Closing_Rpt '"+styleID+"'", _dg_pms_conn),
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Asset_Report\\InternalFixedAssetTransferReport.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Internal Fixed Asset Transfer Report- Factory: " + ComName + ""),
            new ReportParameter("PrintUser", "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }
        //7 no report - external fixed asset transfer Report - DG_External_Fixed_Asset_Transfer_Rpt
        public byte[] ExternalFixedAssetTransferReport(string reportType, int fromComId, int toComId, string UserName)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + fromComId + "'", _specfo_conn);
            DataTable dt2 = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + toComId + "'", _specfo_conn);

            string FromComName = dt.Rows[0]["cCmpName"].ToString();
            string ToComName = dt2.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                _SqlCommon.get_InformationDataTable("DG_External_Fixed_Asset_Transfer_Rpt " + fromComId +  ","  + toComId  , _dg_Asst_Mgt),
                //_SqlCommon.get_InformationDataTable("Mr_Cutting_Closing_Style_Wise_Report '"+styleID+"'", _dg_pms_conn),
                //_SqlCommon.get_InformationDataTable("Mr_Cutting_Closing_Style_Line_Wise_Report '"+styleID+"'", _dg_pms_conn),
                //     _SqlCommon.get_InformationDataTable("Mr_Cut_Fabrics_Closing_Rpt '"+styleID+"'", _dg_pms_conn),
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Asset_Report\\ExternalFixedAssetTransferReport.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",FromComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "External Fixed Asset Transfer Report - From Factory: " + FromComName + "; To Factory: " + ToComName + ""),
            new ReportParameter("PrintUser", "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }

        public byte[] ScheduledMaintenanceReport(string reportType, int comID, string UserName)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {

                 _SqlCommon.get_InformationDataTable("DG_Scheduled_Maintenance_Rpt '"+ comID + "'",_dg_Asst_Mgt)

            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Asset_report\\ScheduledMaintenance Report.rdlc";
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Scheduled Maintenance Report- Fectory: "+ComName+""),
            new ReportParameter("PrintUser",  "" + UserName + "")
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
