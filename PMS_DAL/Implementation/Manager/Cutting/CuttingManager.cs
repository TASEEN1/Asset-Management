
using Microsoft.Reporting.Map.WebForms.BingMaps;
using PMS_BLL.Interfaces.Manager.Cutting;
using PMS_BLL.Utility;
using PMS_BOL.Models;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.Intrinsics.Arm;
using static System.Net.Mime.MediaTypeNames;


namespace PMS_DAL.Implementation.Manager.Cutting
{
    public class CuttingManager : ICuttingManager
    {
        private readonly Dg_SqlCommon _SqlCommon;
        private readonly SqlConnection _dg_pms_conn;
        private readonly SqlConnection _specfo_conn;
        private readonly SqlConnection _dg_barcode_conn;
        private readonly SqlConnection _dg_smartCode_conn;
        public CuttingManager(Dg_SqlCommon sqlCommon)
        {
            _SqlCommon = sqlCommon;
            _dg_pms_conn = new SqlConnection(Dg_Getway.PmsCon);
            _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
            _dg_barcode_conn = new SqlConnection(Dg_Getway.dg_barcode);
            _dg_smartCode_conn = new SqlConnection(Dg_Getway.dg_smart_code);
        }

        public async Task<DataTable> GetCompany()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("Mr_DD_Company", _dg_pms_conn);
            return data;
        }

        public async Task<DataTable> GetYear()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("Mr_DD_Year", _dg_pms_conn);
            return data;
        }

        public async Task<DataTable> GetBuyer(int comID, int year)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("Mr_DD_Buyer '" + comID + "', '" + year + "'", _dg_pms_conn);
            return data;
        }

        public async Task<DataTable> GetStyle(int comID, int buyerID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("Mr_DD_Style '"+comID+"','"+buyerID+"'", _dg_pms_conn);
            return data;
        }

        public async Task<DataTable> GetCuttingStyleReport(int comID, int buyerID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT DISTINCT SpecFo.dbo.Smt_StyleMaster.nStyleID, SpecFo.dbo.Smt_StyleMaster.cStyleNo FROM     SpecFo.dbo.Smt_BuyerName LEFT OUTER JOIN SpecFo.dbo.Smt_StyleMaster ON SpecFo.dbo.Smt_BuyerName.nBuyer_ID = SpecFo.dbo.Smt_StyleMaster.nAcct RIGHT OUTER JOIN dbo.TUP_Bundles ON SpecFo.dbo.Smt_StyleMaster.nStyleID = dbo.TUP_Bundles.nStyleID where nAcct='" + buyerID + "' and dbo.TUP_Bundles.nCompanyID='"+comID+"'   order by cStyleNo", _dg_barcode_conn);
            return data;
        }

        public async Task<DataTable> GetStyleInfo(int buyerID, int styleID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT DISTINCT dbo.Smt_GmtType.nGmtCode, dbo.Smt_GmtType.cGmetDis, dbo.Smt_StyleMaster.nTotOrdQty FROM dbo.Smt_StyleMaster INNER JOIN  dbo.Smt_GmtType ON dbo.Smt_StyleMaster.cGmtType = dbo.Smt_GmtType.nGmtCode where nAcct='" + buyerID + "' and nStyleID='" + styleID + "' and  ConfirmStatus='CONF'", _specfo_conn);
            return data;
        }

        public async Task<DataTable> GetCutMasterView(int styleID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("Mr_GridView_CutMaster '" + styleID + "'", _dg_pms_conn);
            return data;
        }

        public async Task<string> SaveCutMaster(CutMaster cut)
        {
            string message = string.Empty;
            await _dg_pms_conn.OpenAsync();

            try
            {
                SqlCommand cmd = new SqlCommand("Mr_Cut_Number_Update", _dg_pms_conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Style", cut.StyleID);
                cmd.Parameters.AddWithValue("@PO_No", cut.PO);
                cmd.Parameters.AddWithValue("@PO_Id", cut.POID);
                cmd.Parameters.AddWithValue("@nYear", cut.Year);
                cmd.Parameters.AddWithValue("@company", cut.CompanyID);
                cmd.Parameters.AddWithValue("@EntDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@Enter_User", cut.UserName);
                cmd.Parameters.AddWithValue("@CutCompanyID", cut.CutCompanyID);
                cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                await cmd.ExecuteNonQueryAsync();
                message = (string)cmd.Parameters["@ERROR"].Value;

            }
            catch (Exception ex)
            {
                ex.ToString();

            }

            finally
            {

                _dg_pms_conn.Close();

            }

            return message;
        }

        public async Task<DataTable> GetCuttingYear(int comID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select DISTINCT nYear from Web_Smt_CutMast where CutCompanyID='" + comID + "' order by nYear", _dg_barcode_conn);
            return data;
        }

        public async Task<DataTable> GetCuttingStyle(int Year, int comID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("Mr_DD_Style_1 '" + Year + "','" + comID + "'", _dg_pms_conn);
            return data;
        }

        public async Task<DataTable> GetCuttingPO(int styleID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("Mr_DD_PO '" + styleID + "'", _dg_pms_conn);
            return data;
        }

        public async Task<DataTable> GetCuttingCountry(int styleID, string POID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("Mr_DD_Country '" + styleID + "','" + POID + "'", _dg_pms_conn);
            return data;
        }

        public async Task<DataTable> GetCuttingCutNo(int styleID, string POID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT nCutNum FROM dbo.Smt_OrdersMaster WHERE  (nCutNum <> 0) and  nOStyleId='" + styleID + "' and cOrderNu='" + POID + "' ", _specfo_conn);
            return data;
        }

        public async Task<DataTable> GetCuttingLayNo(int styleID, string POID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("Select Max(CAST(cLayNo as INT)) from TUp_LayColour where nStyleID='" + styleID + "'and cPoLot='" + POID + "'", _dg_barcode_conn);
            return data;
        }

        public async Task<DataTable> GetCuttingSizeRatio(int styleID, string POID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT SizeNo,OrgSize FROM dbo.View_PivotSize WHERE  (nStyleID = '" + styleID + "') and cLotNo='" + POID + "' and OrgSize!='SIZE ALL'", _specfo_conn);
            return data;
        }

        public async Task<DataTable> GetCuttingColor(int styleID, string POID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT DISTINCT dbo.Smt_Colours.cColour, dbo.Smt_Colours.nColNo FROM     dbo.View_PivotColorQtyBySize INNER JOIN  dbo.Smt_Colours ON dbo.View_PivotColorQtyBySize.nCol = dbo.Smt_Colours.nColNo WHERE  (nstyCd = '" + styleID + "') and cLot='" + POID + "' ", _specfo_conn);
            return data;
        }

        public async Task<DataTable> GetCuttingFabricDetails(int styleID, string POID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT Smt_Colours.nColNo, Smt_Colours.cColour, Smt_OrdFabColor.nStyleID, Smt_OrdFabColor.cLot FROM  Smt_OrdFabColor INNER JOIN Smt_Colours ON Smt_OrdFabColor.nFabColNo = Smt_Colours.nColNo WHERE  (nStyleID = '" + styleID + "') and cLot='" + POID + "'", _specfo_conn);
            return data;
        }

        public async Task<string> SaveCutting(List<CuttingSave> cut)
        {
            string message = string.Empty;
            await _dg_pms_conn.OpenAsync();

            try
            {
                foreach (CuttingSave cutting in cut)
                {
                    SqlCommand cmd = new SqlCommand("Mr_Cut_TUp_LayColour_Save", _dg_pms_conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cutNo", cutting.cutNo);
                    cmd.Parameters.AddWithValue("@cyear", cutting.cyear);
                    cmd.Parameters.AddWithValue("@clayNo", cutting.lay);
                    cmd.Parameters.AddWithValue("@cRow", 1);
                    cmd.Parameters.AddWithValue("@cfabricColor", cutting.fabriccolor);

                    cmd.Parameters.AddWithValue("@cfabshed", cutting.fabricshade);
                    cmd.Parameters.AddWithValue("@cfablot", cutting.lot);
                    cmd.Parameters.AddWithValue("@cplies", cutting.plies);
                    cmd.Parameters.AddWithValue("@cbundleqty", cutting.qty);
                    cmd.Parameters.AddWithValue("@creallay", cutting.reallay);
                    cmd.Parameters.AddWithValue("@centdate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@centuser", cutting.UserName);
                    cmd.Parameters.AddWithValue("@cstyleid", cutting.styleID);
                    cmd.Parameters.AddWithValue("@cplot", cutting.pono);
                    //morucmd.Parameters.AddWithValue("@cplot", DDPONO.SelectedItem.Text); for Mr_DB
                    cmd.Parameters.AddWithValue("@Company", cutting.companyID);
                    cmd.Parameters.AddWithValue("@Country", cutting.countryID);
                    cmd.Parameters.AddWithValue("@prod_date", cutting.productiondate);
                    cmd.Parameters.AddWithValue("@remarks", cutting.remarks);
                    cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                    cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                    await cmd.ExecuteNonQueryAsync();
                    message = (string)cmd.Parameters["@ERROR"].Value;
                }
                
            }
            catch (Exception ex)
            {
                ex.ToString();

            }

            finally
            {

                _dg_pms_conn.Close();

            }

            return message;
        }
        public async Task<string> SaveCuttingLaySize(List<CuttingLaySize> CLS)
        {
            string message = string.Empty;
            await _dg_pms_conn.OpenAsync();

            try
            {
                foreach (CuttingLaySize CLS1 in CLS)
                {
                    SqlCommand cmd = new SqlCommand("Mr_Cut_TUp_Lay_Size_Save", _dg_pms_conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cutNo", CLS1.cutNo);
                    cmd.Parameters.AddWithValue("@cyear", CLS1.cyear);
                    cmd.Parameters.AddWithValue("@clayNo", CLS1.lay);
                    cmd.Parameters.AddWithValue("@cRow", CLS1.crow);
                    cmd.Parameters.AddWithValue("@creallay", CLS1.reallay);
                    cmd.Parameters.AddWithValue("@centdate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@centuser", CLS1.UserName);
                    cmd.Parameters.AddWithValue("@cstyleid", CLS1.styleID);
                    cmd.Parameters.AddWithValue("@cplot", CLS1.lot);
                    cmd.Parameters.AddWithValue("@Country", CLS1.countryID);
                    cmd.Parameters.AddWithValue("@CutSize", CLS1.size);
                    cmd.Parameters.AddWithValue("@Ratio", CLS1.ratio);
                    cmd.Parameters.AddWithValue("@OrderPO", CLS1.pono);
                    cmd.Parameters.AddWithValue("@prod_date", CLS1.productiondate);
                    cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                    cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                    await cmd.ExecuteNonQueryAsync();
                    message = (string)cmd.Parameters["@ERROR"].Value;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();

            }

            finally
            {

                _dg_pms_conn.Close();

            }

            return message;
        }

        #region For Cutting Approval
        public async Task<DataTable> ForApprovalCuttingView(int comID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT DISTINCT dbo.TUP_laySize.nCutNo, dbo.TUP_laySize.nYear, dbo.TUP_laySize.cLayNo, dbo.TUP_laySize.cRealLay, dbo.TUP_laySize.prod_date AS ProDate, dbo.TUP_laySize.nPoLot, dbo.TUP_laySize.nStyleID,dbo.TUP_laySize.nOrderPO, SpecFo.dbo.Smt_Company.cCmpName, SpecFo.dbo.Smt_StyleMaster.cStyleNo, SpecFo.dbo.Smt_Users.cUserFullname AS cEntUser FROM     dbo.TUP_laySize INNER JOIN dbo.TUp_LayColour ON dbo.TUP_laySize.nCutNo = dbo.TUp_LayColour.nCutNo AND dbo.TUP_laySize.cLayNo = dbo.TUp_LayColour.cLayNo AND dbo.TUP_laySize.nYear = dbo.TUp_LayColour.nYear AND dbo.TUP_laySize.nStyleID = dbo.TUp_LayColour.nStyleID AND  dbo.TUP_laySize.nPoLot = dbo.TUp_LayColour.cPoLot INNER JOIN SpecFo.dbo.Smt_Company ON dbo.TUp_LayColour.cCompany = SpecFo.dbo.Smt_Company.nCompanyID INNER JOIN  SpecFo.dbo.Smt_StyleMaster ON dbo.TUP_laySize.nStyleID = SpecFo.dbo.Smt_StyleMaster.nStyleID INNER JOIN SpecFo.dbo.Smt_Users ON dbo.TUP_laySize.cEntUser = SpecFo.dbo.Smt_Users.cUserName WHERE(dbo.TUP_laySize.cut_com = 0) AND(SpecFo.dbo.Smt_Company.nCompanyID = '" + comID+"') ORDER BY ProDate DESC", _dg_barcode_conn);
            return data;
        }

        public async Task<bool> ForApprovalCutting(List<CutForApprove> App)
        {
            bool flag = false;
            try
            {
                foreach (CutForApprove Apps in App)
                {
                    await _dg_pms_conn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("Mr_Bundle_Numbering_Approve", _dg_pms_conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nStyleID", Apps.Style);
                    cmd.Parameters.AddWithValue("@CutNo", Apps.cutno);
                    cmd.Parameters.AddWithValue("@layNo", Apps.layno);
                    await cmd.ExecuteNonQueryAsync();
                    await _dg_pms_conn.CloseAsync();
                }
                flag = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                flag = false;
            }
            finally
            {
                await _dg_pms_conn.CloseAsync();
            }
            return flag;
        }

        public async Task<DataTable> ApprovalCuttingView(int comID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT DISTINCT top 100 dbo.TUP_laySize.nCutNo, dbo.TUP_laySize.nYear, dbo.TUP_laySize.cLayNo, dbo.TUP_laySize.cRealLay, dbo.TUP_laySize.dEntdate AS ProDate, dbo.TUP_laySize.nStyleID, dbo.TUP_laySize.nOrderPO,SpecFo.dbo.Smt_Company.cCmpName, SpecFo.dbo.Smt_StyleMaster.cStyleNo, SpecFo.dbo.Smt_Users.cUserFullname FROM     dbo.TUP_laySize INNER JOIN dbo.TUp_LayColour ON dbo.TUP_laySize.nCutNo = dbo.TUp_LayColour.nCutNo AND dbo.TUP_laySize.cLayNo = dbo.TUp_LayColour.cLayNo AND dbo.TUP_laySize.nYear = dbo.TUp_LayColour.nYear AND dbo.TUP_laySize.nStyleID = dbo.TUp_LayColour.nStyleID AND dbo.TUP_laySize.nPoLot = dbo.TUp_LayColour.cPoLot INNER JOIN SpecFo.dbo.Smt_Company ON dbo.TUp_LayColour.cCompany = SpecFo.dbo.Smt_Company.nCompanyID INNER JOIN SpecFo.dbo.Smt_StyleMaster ON dbo.TUP_laySize.nStyleID = SpecFo.dbo.Smt_StyleMaster.nStyleID INNER JOIN SpecFo.dbo.Smt_Users ON dbo.TUP_laySize.cEntUser = SpecFo.dbo.Smt_Users.cUserName WHERE  (dbo.TUP_laySize.cut_com = 1) and SpecFo.dbo.Smt_Company.nCompanyID='" + comID + "'  order by dbo.TUP_laySize.dEntdate DESC", _dg_barcode_conn);
            return data;
        }

        public async Task<bool> ApprovalCutting(List<CutForApprove> App)
        {
            bool flag = false;
            try
            {
                foreach (CutForApprove Apps in App)
                {
                    await _dg_pms_conn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("Mr_Bundle_Numbering_Cancel", _dg_pms_conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nStyleID", Apps.Style);
                    cmd.Parameters.AddWithValue("@CutNo", Apps.cutno);
                    cmd.Parameters.AddWithValue("@layNo", Apps.layno);
                    await cmd.ExecuteNonQueryAsync();
                    await _dg_pms_conn.CloseAsync();
                }
                flag = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                flag = false;
            }
            finally
            {
                await _dg_pms_conn.CloseAsync();
            }
            return flag;
        }
        public async Task<bool> CancelCutting(List<CutForApprove> App)
        {
            bool flag = false;
            try
            {
                foreach (CutForApprove Apps in App)
                {
                    await _dg_pms_conn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("Mr_Bundle_Numbering_Cancel", _dg_pms_conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nStyleID", Apps.Style);
                    cmd.Parameters.AddWithValue("@CutNo", Apps.cutno);
                    cmd.Parameters.AddWithValue("@layNo", Apps.layno);
                    await cmd.ExecuteNonQueryAsync();
                    await _dg_pms_conn.CloseAsync();
                }
                flag = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                flag = false;
            }
            finally
            {
                await _dg_pms_conn.CloseAsync();
            }
            return flag;
        }
        #endregion

        public async Task<DataTable> GetCompanyUserWise(int comID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT DISTINCT SpecFo.dbo.Smt_Company.nCompanyID, SpecFo.dbo.Smt_Company.cCmpName FROM     dbo.TUP_Bundles INNER JOIN  SpecFo.dbo.Smt_Company ON dbo.TUP_Bundles.nCompanyID = SpecFo.dbo.Smt_Company.nCompanyID and  SpecFo.dbo.Smt_Company.nCompanyID='" + comID +"'", _dg_barcode_conn);
            return data;
        }
        public async Task<DataTable> GetLay(int styleID, string POID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT DISTINCT cLayNo FROM TUP_Bundles  where cPONo='" + POID + "' and nStyleID='" + styleID + "' order by cLayNo DESC", _dg_barcode_conn);
            return data;
        }

    }
}
