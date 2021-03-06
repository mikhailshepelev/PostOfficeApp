using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Enumerations;
using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ValidationService : IValidationService
    {
        private readonly DataContext _context;
        public ValidationService(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> ShipmentExists(string number)
        {
            return await _context.Shipments.AnyAsync(x => x.Number == number);
        }

        public bool AirportIsEligible(string airport)
        {
            foreach (string s in Enum.GetNames(typeof(Airport)))
            {
                if (airport.Equals(s))
                {
                    return true;
                }
            }
            return false;
        }

        public bool DateIsIneligible(DateTime flightDate)
        {
            return DateTime.Compare(DateTime.Now, flightDate) > 0;
        }

        public async Task<bool> ShipmentHasBagsWithoutParcels(int shipmentId) {
            var bags = await _context.ParcelsBags.Where(b => b.ShipmentId == shipmentId).ToListAsync();
            foreach(var bag in bags) {
                if (bag.ParcelsCount == 0) {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> ShipmentHasNoBags(int shipmentId) {
            List<Bag> bags = await _context.Bags.Where(b => b.ShipmentId == shipmentId).ToListAsync();
            return bags.Count == 0;
        }

        public async Task<bool> BagExists(string number)
        {
            return await _context.Bags.AnyAsync(x => x.Number == number);
        }

        public async Task<bool> ParcelExists(string number)
        {
            return await _context.Parcels.AnyAsync(x => x.Number == number);
        }
        public async Task<bool> IsBagFinalized(int parcelsBagId)
        {
            ParcelsBag bag = await _context.ParcelsBags.SingleOrDefaultAsync(x => x.Id == parcelsBagId);
            return bag.isFinalized;
        }
    }
}