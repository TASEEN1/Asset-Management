using PMS_BOL.Models.Order_Mgt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.OrderMgt
{
    public interface IProductionManager
    {
        //Dropdown
        public Task<DataTable> GetmachineNo();
        public Task<DataTable> GetShift();

        //Modal
        public Task<DataTable> GetmachineView();
        public Task<string> MachineDetailsSave(List<MachineDetails>MC);
        public Task<string> shiftSave(List<ShiftDetails>SF);

        // save
        public Task<string> Production_padding_save (List<ProductionModel> PD);

    }
}
