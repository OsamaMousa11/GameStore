﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContract
{
    public interface IDevicesService
    {
       
        IEnumerable<SelectListItem> GetListDevices();
        
    }
}
