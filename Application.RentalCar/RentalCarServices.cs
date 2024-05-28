﻿using Application.RentalCar.ViewModels;
using Domain.RentalCar;

namespace Application.RentalCar
{
    /// <summary>
    /// Application Services 應用層的 RentalCarServices 租車服務
    /// </summary>
    public class RentalCarServices
    {
        //private IVehicle _iVehicle;
        private readonly IQueryRentalCarUseCase _queryRentalCarUserCase;

        public RentalCarServices(IQueryRentalCarUseCase queryRentalCarUserCase)
        {
            //_iVehicle = vehicle;
            _queryRentalCarUserCase = queryRentalCarUserCase;
        }

        public IEnumerable<IVehicle> GetAllCars()
        {
            return _queryRentalCarUserCase.GetAllCars();
        }

        public IEnumerable<AccountViewModel> GetAllAccounts()
        {
            return _queryRentalCarUserCase.GetAllAccounts();
        }

        public TimeSpan ChoiseRentalTime(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateRentalCost(int daysRented, VehicleType vehicleType)
        {
            var result = _queryRentalCarUserCase.GetAllCars()
                .Where(c => c.GetVehicleType() == vehicleType)
                .FirstOrDefault();

            return result!.CalculateRentalCost(daysRented);
        }
    }
}
