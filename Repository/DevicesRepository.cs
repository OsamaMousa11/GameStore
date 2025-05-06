using GameStore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DevicesRepository:IDevicesRepository
    {
        private readonly AppDbContext _db;
        public DevicesRepository(AppDbContext db)
        {
            _db = db;
        }
        public List<SelectListItem> GetListDevice()
        {
            return _db.Devices
           .Select(x => new SelectListItem
           {
               Value = x.Id.ToString(),
               Text = x.Name
           }).OrderBy(d => d.Text).ToList().ToList();
        }
    }
}
