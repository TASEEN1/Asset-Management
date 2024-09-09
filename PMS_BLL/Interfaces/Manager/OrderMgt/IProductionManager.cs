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
        public Task<DataTable> GetProductionPadding_RefNo();
        public Task<DataTable> GetProductionQuilting_RefNo();


        //GET
        public Task<DataTable> GetPadding_ProductionItemBeforeAdd(int refNO);
        public Task<DataTable> GetPadding_ProductionItemAfterAdd(int refNO);
        public Task<DataTable> GetQuilting_ProductionItemAfterAdd(int refNO);

      


        //Modal
        public Task<DataTable> GetmachineView();
        public Task<DataTable> GetShiftview();
        public Task<string> MachineDetailsSave(List<MachineDetails>MC);
        public Task<string> shiftSave(List<ShiftDetails>SF);

        //Main Page
        public Task<string> Production_padding_save (List<ProductionModel> PD);

    }
}
