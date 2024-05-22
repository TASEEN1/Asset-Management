﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Models
{
    public class Asset_Transfer_Model
    {
        public DateTime Date { get; set; }

        public int ComFrom { get; set; }

        public int ComTo { get; set; }

        public int FloorFrom { get; set; }
        public int FloorTo { get; set;}
        public int LineFrom { get; set; }
        public int LineTo { get; set; }
        public string AssetNo { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public string InputUser { get; set; }

      


    }
}
