﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendManager.Application.Persistence;
using VendManager.Domain;

namespace VendManager.Persistence.Repositories
{
    public class SensorRepository : GenericRepository<Sensor>, ISensorRepository
    {
        public SensorRepository(VendorManagerDbContext context) : base(context)
        {
        }
    }
}