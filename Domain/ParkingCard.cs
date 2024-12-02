using e_parking_garage.Core;

namespace e_parking_garage.Domain
{
    public class ParkingCard : CoreObject
    {
        public string Barcode { get; private set; }
        public DateTime EntryTime { get; private set; }

        private ParkingCard(string barcode, DateTime entryTime)
        {
            Barcode = barcode;
            EntryTime = entryTime;
        }

        public static ParkingCard Create(string barcode, DateTime entryTime)
            => new ParkingCard(barcode, entryTime);
    }
}