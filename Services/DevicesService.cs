using Microsoft.AspNetCore.Mvc.Rendering;
using RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
     public class DevicesService : IDevicesService
    {

        private readonly IDevicesRepository _db;
        public DevicesService(IDevicesRepository db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListDevices()
        {
            return _db.GetListDevice();
        }
    }
}

   

