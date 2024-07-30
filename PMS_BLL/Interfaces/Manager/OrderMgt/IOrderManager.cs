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
        public Task<DataTable> GetItemName();

        public Task<DataTable> GetBuyer();
        public Task<DataTable>GetCustomer();
        public Task<DataTable> GetDia();
        public Task<DataTable> Getgsm();
        public Task<DataTable> Getdesign();
        public Task<DataTable> GetBuyerView();
        public Task<DataTable> GetcustomerView();
        public Task<DataTable>GetcolorView();
        public Task<DataTable> GetdesignView();
        public Task<DataTable> GetDiaView();
        public Task<DataTable> GetgsmView();
        //public Task<DataTable> GetitemView();

        //public Task<DataTable> GetprocessTypeview();
        public Task<DataTable>GetStyleEdit( int custID);
        public Task<DataTable> GetCustomerEdit();
        public Task<DataTable> Getpayment_currency();
        public Task<DataTable> GetRefNoFromOrderReceiving();


        public Task<DataTable> OrderReceivedAddView(string sessionUser);
        public Task<DataTable> GetOrderReceivedAddEditView(int Customer, int Buyer, string Style_no, int Ref_no);

        public Task<string> ColorSave(List<ColorSave>app);
        public Task<string>OrderReceivedAdd(List<OrderReceivingAdd> app);

        public Task<string> OrderReceivedComplete(List<OrderReciveComplete> app);
        public Task<string> ItemNameSave(List<ItemDescriptionSave> app);
        public Task<string> ProcessTypeSave(List<ProcessTypeSave> app);
        public Task<string> BuyerSave(List<BuyerSave> app);
        public Task<string> CustomerSave(List<customerSave> app);
        public Task<string> DiaSave(List<diaSave> app);

        public Task<string> GsmSave(List<gsmSave> app);
        public Task<string> DesignSave(List<designSave> app);
        public Task<string> OrderReceiveDelete(List<orderReceiveDelete> app);
        public Task<string> OrderReceiveEditUpdate(List<OrderReceivingAdd> app);

        public Task<string> CustomerDelete (List<customerSave> app);
        public Task<string> CustomerUpdate(List<customerSave> app);
        public Task<string> BuyerDelete(List<BuyerSave> app);
        public Task<string> BuyerUpdate(List<BuyerSave> app);
        public Task<string> OrderReceiveEditAdd(List<OrderReceivingAdd> app);
        public Task<string> OrderReceiveAddOrderUpdate(List<OrderReceivingAdd> app);
        public Task<string> OrderReceiveAddEditComplete(List<OrderReciveComplete> app);

        //----------------------------Report-----------------------------
        public Task<DataTable> GetReport_Customer();
        public Task<DataTable> GetReport_Style( int custID);











    }
}
