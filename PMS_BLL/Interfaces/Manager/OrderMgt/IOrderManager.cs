using PMS_BOL.Models.OrderMgt;
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
        public Task<DataTable> GetItemDescription();
        public Task<DataTable> GetProcessType();
        public Task<DataTable> Getbuyer();
        public Task<DataTable>GetCustomer();
        public Task<DataTable> GetDia();
        public Task<DataTable> Getgsm();
        public Task<DataTable> Getdesign();
        public Task<DataTable> GetBuyerView();
        public Task<DataTable> GetcustomerView();

        public Task<DataTable> OrderReceivedAddView(int Customer, int Buyer, string Style_no);

        public Task<string> ColorSave(List<ColorSave>app);
        public Task<string>OrderReceivedAdd(List<OrderReceivingAdd> app);

        public Task<string> OrderReceivedComplete(List<OrderReciveComplete> app);
        public Task<string> ItemDescriptionSave(List<ItemDescriptionSave> app);
        public Task<string> ProcessTypeSave(List<ProcessTypeSave> app);
        public Task<string> BuyerSave(List<BuyerSave> app);
        public Task<string> CustomerSave(List<customerSave> app);
        public Task<string> DiaSave(List<diaSave> app);

        public Task<string> GsmSave(List<gsmSave> app);
        public Task<string> DesignSave(List<designSave> app);






    }
}
