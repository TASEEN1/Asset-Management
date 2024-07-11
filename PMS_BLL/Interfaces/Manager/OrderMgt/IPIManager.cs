using PMS_BOL.Models.OrderMgt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.OrderMgt
{
    public interface IPIManager
    {
        public Task<String> GeneratePIAdd(List<PI_Model>app);
        public Task<String> GeneratePI(List<PI_Model> app);
        public Task<DataTable> GetGeneratePIAddView(int customer, int Buyer, string created_By);

    }




}
