﻿using VendManager.Domain;

namespace VendManager.Application.Persistence
{
    public interface ISensorValueHistoryRepository : IGenericRepository<SensorValueHistory>
    {
        Task<List<SensorValueHistory>> GetAllById(long Id);
    }

}
