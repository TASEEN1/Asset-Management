﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Models
{
    public  class Schedule_MaintenanceModel
    {
        public string assetno { get; set; }
        public DateTime nextservicedate { get; set; }
        public string itemreplace { get; set; }
        public DateTime readydate { get; set; }
        public string doneby { get; set; }

        public string InputUser { get; set; }


    }
    
}
