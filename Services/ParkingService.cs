﻿using e_parking_garage.Domain;
using e_parking_garage.Enums;
using e_parking_garage.Interfaces;
using e_parking_garage.Managers;
using e_parking_garage.Policies;

namespace e_parking_garage.Services
{
    public static class ParkingService
    {
        private static List<ParkingCard> _ParkingCards = new();
        private static List<ParkingSlot> _ParkingSlots = new();
        private static ParkingLot _ParkingLot;
        private static Dictionary<long, ParkingSlot> _OccupiedSlots = new();
        private static IPricingPolicy _PricingPolicy;

        static ParkingService()
        {
            var parkingSlots = new List<ParkingSlot>();
            
            for (int x = 1; x <= 10; x++)
            {
                parkingSlots.Add(ParkingSlot.Create(x));
            }

            _PricingPolicy = new ParkingLotPolicy(100);
            _ParkingLot = ParkingLot.Create(parkingSlots, SlotAvaliabilityStatus.Free);
        }

        public static void EnterToParkingLot()
        {
            ParkingSlot availableSlot = ParkingSlotManager.FindAvailableSlot(_ParkingLot);

            if (availableSlot is null)
                throw new InvalidOperationException("There is no avaliable free parking slot at the moment.");

            var parkingCard = ParkingCardManager.CreateCard();

            _ParkingLot.AddParkingCard(parkingCard);
            _ParkingLot.UpdateStatus();

            ParkingSlotManager.MarkSlotAsOccupied(availableSlot);
            _OccupiedSlots[parkingCard.Id] = availableSlot;

            Console.WriteLine($"Vehicle successfully registered. Your card id is: {parkingCard.Id}, Parking Slot: {availableSlot.SlotNumber} BARCODE: {parkingCard.Barcode}");
            return;
        }

        public static void ExitVehicle(long cardId)
        {
            var parkingCard = SearchParkingCardById(cardId);
            
            var occupiedSlot = _OccupiedSlots[parkingCard.Id];

            if (occupiedSlot is null)
                throw new InvalidOperationException("This slot doesn't exist.");

            ParkingSlotManager.MarkSlotAsFree(occupiedSlot);

            Console.WriteLine($"Vehicle has successfully exited Parking Lot. Total expenses: {CalculateExpenses(cardId)} RSD.");

            _OccupiedSlots.Remove(cardId);
            _ParkingLot.RemoveParkingCard(parkingCard);
            _ParkingLot.UpdateStatus();
        }

        public static double CalculateExpenses(long parkingId)
        {
            var parkingCard = _ParkingLot.ParkingCards.SingleOrDefault(x=> x.Id == parkingId);
            
            if(parkingCard is null)
                throw new InvalidOperationException("There is no parking card with given id.");

            var parkingDuration = DateTime.Now - parkingCard.EntryTime;
            
            return _PricingPolicy.CalculateCost(parkingDuration);
        }

        public static ParkingCard SearchParkingCardById(long id)
        {
            var card = _ParkingLot.ParkingCards.SingleOrDefault(card => card.Id == id);

            if (card is null)
                throw new InvalidOperationException("Card not found with given id.");
            else
                Console.WriteLine($"Card found! ID: {card.Id}, Entry Time: {card.EntryTime}, Barcode: {card.Barcode}");

            return card;
        }

        public static ParkingCard SearchParkingCardByBarcode(string barcode)
        {
            var card = _ParkingLot.ParkingCards.SingleOrDefault(card => card.Barcode == barcode);

            if (card is null)
                throw new InvalidOperationException($"No card found with barcode: {barcode}");
            else
                Console.WriteLine($"Card found! ID: {card.Id}, Entry Time: {card.EntryTime}, Barcode: {card.Barcode}");

            return card;
        }
    }
}
