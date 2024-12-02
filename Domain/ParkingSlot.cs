using e_parking_garage.Core;

namespace e_parking_garage.Domain
{
    public class ParkingSlot : CoreObject
    {
        public int SlotNumber { get; private set; }
        public bool IsOccupied { get; private set; }

        private ParkingSlot(int slotNumber)
        {
            SlotNumber = slotNumber;
            IsOccupied = false;
        }

        public static ParkingSlot Create(int slotNumber)
            => new ParkingSlot(slotNumber);

        public void MarkAsOccupied()
        {
            IsOccupied = true; 
        }

        public void MarkAsFree()
        {
            IsOccupied = false;
        }
    }
}
