﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NWCodeFirstMVC.Domain.Dto
{
    public class SalesByCategoryDTO {
    
    [DataMember]
    public string ProductName { get; set; }

    [DataMember]
    public string TotalPurchase { get; set; }

    }
}
