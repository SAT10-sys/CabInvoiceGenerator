using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cab_Invoice_Generator
{
    public class Ride_Repository
    {
        public Dictionary<int, List<Ride>> rideRepository;
        public Ride_Repository()
        {
            rideRepository = new Dictionary<int, List<Ride>>();
        }
        public void Add(int userId, List<Ride> rideList)
        {
            if (rideList.Any(e => e == null) || rideList == null)
                throw new Cab_Invoice_Exception(Cab_Invoice_Exception.ExceptionType.NULL_RIDES, "Rides are null");
            if (rideRepository.ContainsKey(userId))
                rideRepository[userId] = rideList;
            if (rideRepository.ContainsKey(userId) == false)
                rideRepository.Add(userId, rideList);
        }
        public List<Ride> GetRides(int userId)
        {
            try
            {
                return this.rideRepository[userId];
            }
            catch (Exception)
            {
                throw new Cab_Invoice_Exception(Cab_Invoice_Exception.ExceptionType.INVALID_USERID, "Invalid UserID");
            }
        }
    }
}
