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

    }
}
