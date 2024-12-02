using e_parking_garage.Domain;

namespace e_parking_garage.NewFolder
{
    public static class ParkingSlotManager
    {
        public static ParkingSlot FindAvailableSlot(ParkingLot parkingLot)
            => parkingLot.ParkingSlots.FirstOrDefault(slot => !slot.IsOccupied);

        public static void MarkSlotAsOccupied(ParkingSlot slot)
        {
            slot.MarkAsOccupied();
        }

        public static void MarkSlotAsFree(ParkingSlot slot)
        {
            slot.MarkAsFree();
        }
    }
}
