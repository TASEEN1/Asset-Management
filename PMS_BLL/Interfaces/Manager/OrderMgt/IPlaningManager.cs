﻿using PMS_BOL.Models.Order_Mgt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.OrderMgt
{
    public interface IPlaningManager
    {
        //DROP DOWN
        public Task<DataTable> Get_PI_Number();


        //VIEW
        public Task<DataTable> GetPlaning_Details_BeforeAdd( string Pi_Number, int Proc_ID);
        public Task<DataTable> GetPlaning_Details_AfterAdd(string Pi_Number, int Proc_ID,string sessionUser);




        //ADD/SAVE
        public Task<string> PlaningSave(List<PlaningModel>PL); 
        public Task<string>PlaningComplete(List<PlaningModel>PL);
        public Task<string> PL_Delete(List<PlaningModel> PL);

    }
}
