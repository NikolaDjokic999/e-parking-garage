using e_parking_garage.Interfaces;

namespace e_parking_garage.Policies
{
    public class ParkingLotPolicy : IPricingPolicy
    {
        private readonly double _hourlyRate;

        public ParkingLotPolicy(double hourlyRate)
        {
            _hourlyRate = hourlyRate;
        }

        public double CalculateCost(TimeSpan parkingDuration)
            => Math.Ceiling(parkingDuration.TotalHours) * _hourlyRate;
    }
}
