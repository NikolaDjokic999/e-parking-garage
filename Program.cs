using e_parking_garage.Helpers;
using e_parking_garage.Services;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            ShowMenu();
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    HandleEnterVehicle();
                    break;
                case "2":
                    HandleSearchParkingCardById();
                    break;
                case "3":
                    HandleSearchParkingCardByBarcode();
                    break;
                case "4":
                    HandleCalculatePrice();
                    break;
                case "5":
                    HandleExitVehicle();
                    break;
                case "6":
                    Console.WriteLine("Exiting application...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("\nChoose an option:");
        Console.WriteLine("1. Enter Vehicle to Parking Lot");
        Console.WriteLine("2. Search Parking Card by Id");
        Console.WriteLine("3. Search Parking Card by Barcode");
        Console.WriteLine("4. Calculate the Price");
        Console.WriteLine("5. Exit Vehicle from Parking Lot");
        Console.WriteLine("6. Exit Application");
        Console.Write("Your option: ");
    }

    static void HandleEnterVehicle()
    {
        try
        {
            ParkingService.EnterToParkingLot();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void HandleSearchParkingCardById()
    {
        Console.Write("Enter the ID of the Parking Card: ");
        try
        {
            InputValidationHelper.TryGetValidatedId(out long cardId);

            ParkingService.SearchParkingCardById(cardId);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Invalid Opertaion:" + ex.Message);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Invalid Format:" + ex.Message);
        }
    }

    static void HandleSearchParkingCardByBarcode()
    {
        Console.Write("Enter the Barcode of the Parking Card: ");
        try
        {
            var input = Console.ReadLine();

            ParkingService.SearchParkingCardByBarcode(input);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Invalid Opertaion:" + ex.Message);
        }
    }

    static void HandleCalculatePrice()
    {
        Console.Write("Enter the ID of the Parking Card: ");
        try
        {
            InputValidationHelper.TryGetValidatedId(out long cardId);
        
            var totalExpenses = ParkingService.CalculateExpenses(cardId);
            Console.WriteLine($"Total Expenses: {totalExpenses} RSD");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Invalid Opertaion:" + ex.Message);
        }
        catch(FormatException ex)
        {
            Console.WriteLine("Invalid Format:" + ex.Message);
        }
    }

    static void HandleExitVehicle()
    {
        Console.Write("Enter the ID of the Parking Card: ");
        try
        {
            InputValidationHelper.TryGetValidatedId(out long cardId);

            ParkingService.ExitVehicle(cardId);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Invalid Opertaion:" + ex.Message);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Invalid Format:" + ex.Message);
        }
    }
}
