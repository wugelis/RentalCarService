﻿using Domain.RentalCar;

namespace Application.RentalCar
{
    /// <summary>
    /// 
    /// </summary>
    public interface IQueryRentalCarUserCase
    {
        /// <summary>
        /// 查詢所有可租用車輛資料
        /// </summary>
        /// <returns></returns>
        IEnumerable<IVehicle> GetAllCars();
    }
}