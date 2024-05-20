using PMS_BOL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.AssetMaster
{
    public interface IAsset_TransferManager
    {
        public Task<DataTable> Get_Company_CH();
        public Task<DataTable> BindFloor( int ComID);

        public Task<DataTable> GetLine( int ComID , int FloorID);
        public Task<DataTable> IGet_Asst_No(int ComID, int floorID, int LineID);

        public Task<DataTable> EGet_Asst_No(int ComID);

        public Task<string> Internal_Transfer_Save(List<Asset_Transfer_Model> App);
        public Task<DataTable> Internal_Transfer_View(int ComID , string UID);


    }
}
