using e_parking_garage.Core;
using e_parking_garage.Enums;

namespace e_parking_garage.Domain
{
    public class ParkingLot : CoreObject
    {
        public List<ParkingSlot> ParkingSlots { get; private set; }
        public List<ParkingCard> ParkingCards { get; private set; }
        public SlotAvaliabilityStatus Status { get; private set; }
        public int TotalNumberOfSlots => ParkingSlots.Count;

        private ParkingLot(List<ParkingSlot> parkingSlots, SlotAvaliabilityStatus status)
        {
            ParkingSlots = parkingSlots ?? new List<ParkingSlot>(); 
            Status = status;
            ParkingCards = new();
        }

        public static ParkingLot Create(List<ParkingSlot> parkingSlots, SlotAvaliabilityStatus status)
           => new ParkingLot(parkingSlots, status);

        public void AddParkingCard(ParkingCard card)
        {
            ParkingCards.Add(card);
        }

        public void RemoveParkingCard(ParkingCard card)
        {
            ParkingCards.Remove(card);
        }

        public void UpdateStatus()
        {
            if (ParkingSlots.Count(slot => slot.IsOccupied) == TotalNumberOfSlots)
                Status = SlotAvaliabilityStatus.Occupied;
            else
                Status = SlotAvaliabilityStatus.Free;
        }
    }
}
