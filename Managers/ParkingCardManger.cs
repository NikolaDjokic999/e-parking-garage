using e_parking_garage.Domain;

namespace e_parking_garage.Managers
{
    public static class ParkingCardManager
    {
        public static ParkingCard CreateCard()
            => ParkingCard.Create(ParkingCard.GenerateBarcode(), DateTime.Now);
    }
}
