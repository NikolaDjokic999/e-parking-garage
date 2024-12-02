
namespace e_parking_garage.Interfaces
{
    internal interface IPricingPolicy
    {
        double CalculateCost(TimeSpan parkingDuration);
    }
}
