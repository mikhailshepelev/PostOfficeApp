using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Model;

namespace API.Services
{
    public interface IValidationService
    {
        Task<bool> ShipmentExists(string number);
        bool AirportIsEligible(string airport);
        bool DateIsIneligible(DateTime flightDate);
        Task<bool> ShipmentHasBagsWithoutParcels(int shipmentId);
        Task<bool> ShipmentHasNoBags(int shipmentId);
        Task<bool> BagExists(string number);
    }
}