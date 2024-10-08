using PMS_BLL.Interfaces.Manager.OrderMgt;
using PMS_BLL.Utility;
using PMS_BOL.Functions;
using PMS_BOL.Models.Order_Mgt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_DAL.Implementation.Manager.OrderMgt
{
    public  class PaddingRawmaterialManager : IPaddingRawmaterialManager
    {
        private readonly Dg_SqlCommon _SqlCommon;
        private readonly SqlConnection _specfo_conn;
        private readonly SqlConnection _dg_Asst_Mgt;
        private readonly SqlConnection _SpecFoInventory;
        private readonly SqlConnection _dg_Oder_Mgt;

        public PaddingRawmaterialManager(Dg_SqlCommon sqlCommon)
        {
            _SqlCommon = sqlCommon;
            _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
            _dg_Asst_Mgt = new SqlConnection(Dg_Getway.dg_Asst_Mgt);
            _SpecFoInventory = new SqlConnection(Dg_Getway.SpecFoInventory);
            _dg_Oder_Mgt = new SqlConnection(Dg_Getway.dg_Oder_Mgt);

           
        }

        // Drop Down

        public async Task<DataTable> Get_mianCetegory()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select * from dg_dimtbl_rawmat_maincate order by mrm_main_cate ", _dg_Oder_Mgt);
            return data;
        }

        public async Task<DataTable> Get_subCategory(int mainCateID)
        {
            var query = $"select * from dg_dimtbl_rawmat_subcate where srm_mrm_id={mainCateID} order by srm_sub_cate";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;
        }

        //View
        public async Task<DataTable> GetPadding_raw_material_After_View(DateTime date, int paddingMachineId)
        {
            var query = $"dg_raw_material_padding_AfterSave_view '{date}',{paddingMachineId}";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetPadding_raw_material_After_View_Remarks(DateTime date, int paddingMachineId)
        {
            var query = $"dg_raw_material_padding_AfterSave_view_remarks '{date}',{paddingMachineId}";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetPadding_raw_meterial_Before_view(DateTime date,int paddingMachineId)
        {
            var query = $"dg_raw_material_padding_BeforeSave_view '{date}',{paddingMachineId}";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;
        }

       
        // save
        public async Task<string> padding_raw_material_Save(RawmaterailSaveRequest rawmaterailSaveRequest)
        {
            string msg = string.Empty;
            string message = string.Empty;
            string message1 = string.Empty;

            await _dg_Oder_Mgt.OpenAsync();
            int count = 0, count1 = 0;


            try
            {
                foreach ( var ord in  rawmaterailSaveRequest.rawmaterialModels)
                {

                    SqlCommand cmd = new SqlCommand("dg_raw_material_padding_save", _dg_Oder_Mgt);
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@padrm_createdBy_compId", ord.ComID);
                        cmd.Parameters.AddWithValue("@padrm_maincate", ord.Paddingrm_mainCetegory);
                        cmd.Parameters.AddWithValue("@padrm_qty", ord.Paddingrm_qty);
                        cmd.Parameters.AddWithValue("@padrm_mc_pad", ord.Paddingrm_Mc_pad);
                        cmd.Parameters.AddWithValue("@padrm_subcate", ord.Paddingrm_subCategory);
                        cmd.Parameters.AddWithValue("@padrm_prod_date", ord.production_Date.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@padrm_created_by", ord.paddingrm_Created_by);
                        //cmd.Parameters.AddWithValue("@padrm_remarks", ord.Paddingrm_remarks);
                        cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                        cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                        count = await cmd.ExecuteNonQueryAsync();
                        message = (string)cmd.Parameters["@ERROR"].Value;
                    }

                }
                foreach (var ord in rawmaterailSaveRequest.paddingRemarks_Models)
                {
                    using (SqlCommand cmd2 = new SqlCommand("dg_raw_material_padding_save_remarks", _dg_Oder_Mgt))
                    {
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@padrm_mc_pad ", ord.paddingrm_mc_pad);
                        cmd2.Parameters.AddWithValue("@padrm_prod_date", ord.padding_production_Date.ToString("yyyy-MM-dd"));
                        cmd2.Parameters.AddWithValue("@padrm_rem_sl", ord.paddingrm_SL);
                        cmd2.Parameters.AddWithValue("@padrm_rem", ord.padding_remarks);
                        cmd2.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                        cmd2.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                        count1 = await cmd2.ExecuteNonQueryAsync();
                        message1 = (string)cmd2.Parameters["@ERROR"].Value;



                    }
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                _dg_Oder_Mgt.Close();
            }
            if (count > 0 && count1 > 0)
            {
                msg = message;
            }
            else if (count > 0)
            {
                msg = message;
            }
            else if(count1 > 0)
            {
                msg= message1;
            }
            else
            {
                msg = "Operation Failed";
            }
            return (message + " "+ message1);
        }

        public async Task<string> padding_raw_material_Delete(List<RawmaterialModel> RM)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();


            try
            {
                foreach (RawmaterialModel ord in RM)
                {

                    SqlCommand cmd = new SqlCommand("dg_raw_material_padding_delete_single", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@padrm_id", ord.padrm_id);
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
                _dg_Oder_Mgt.Close();
            }
            return message;
        }

        //public async Task<ResponseGen> padding_raw_material_Save1(RawmaterailSaveRequest rawmaterailSaveRequests)
        //{
        //    string message = string.Empty;
        //    string message1 = string.Empty;

        //    await _dg_Oder_Mgt.OpenAsync();


        //    try
        //    {
        //        foreach (var ord in rawmaterailSaveRequest.rawmaterialModels)
        //        {

        //            SqlCommand cmd = new SqlCommand("dg_raw_material_padding_save", _dg_Oder_Mgt);
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@padrm_createdBy_compId", ord.ComID);
        //                cmd.Parameters.AddWithValue("@padrm_maincate", ord.Paddingrm_mainCetegory);
        //                cmd.Parameters.AddWithValue("@padrm_qty", ord.Paddingrm_qty);
        //                cmd.Parameters.AddWithValue("@padrm_mc_pad", ord.Paddingrm_Mc_pad);
        //                cmd.Parameters.AddWithValue("@padrm_subcate", ord.Paddingrm_subCategory);
        //                cmd.Parameters.AddWithValue("@padrm_prod_date", ord.production_Date.ToString("yyyy-MM-dd"));
        //                cmd.Parameters.AddWithValue("@padrm_created_by", ord.paddingrm_Created_by);
        //                //cmd.Parameters.AddWithValue("@padrm_remarks", ord.Paddingrm_remarks);
        //                cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        //                cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        //                await cmd.ExecuteNonQueryAsync();
        //                message = (string)cmd.Parameters["@ERROR"].Value;
        //            }

        //        }
        //        foreach (var ord in rawmaterailSaveRequest.paddingRemarks_Models)
        //        {
        //            using (SqlCommand cmd2 = new SqlCommand("dg_raw_material_padding_save_remarks", _dg_Oder_Mgt))
        //            {
        //                cmd2.CommandType = CommandType.StoredProcedure;
        //                cmd2.Parameters.AddWithValue("@padrm_mc_pad ", ord.paddingrm_mc_pad);
        //                cmd2.Parameters.AddWithValue("@padrm_prod_date", ord.padding_production_Date.ToString("yyyy-MM-dd"));
        //                cmd2.Parameters.AddWithValue("@padrm_rem_sl", ord.paddingrm_SL);
        //                cmd2.Parameters.AddWithValue("@padrm_rem", ord.padding_remarks);
        //                cmd2.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        //                cmd2.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        //                await cmd2.ExecuteNonQueryAsync();
        //                message1 = (string)cmd2.Parameters["@ERROR"].Value;



        //            }
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //    }
        //    finally
        //    {
        //        _dg_Oder_Mgt.Close();
        //    }
        //    return (message);
        //}
    }
}
