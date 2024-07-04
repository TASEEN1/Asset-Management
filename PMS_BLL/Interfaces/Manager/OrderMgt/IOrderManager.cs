using PMS_BOL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.OrderMgt
{
    public interface IOrderManager
    {
        public Task<DataTable> GetPaymentType();
        public Task<DataTable> GetColor();
        public Task<DataTable>GetUnit();

        public Task<string> ColorSave(List<ColorSave>app);
    }
}
