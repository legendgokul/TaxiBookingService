using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

class ProgramStart
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter number of taxi");
        var count = int.Parse(Console.ReadLine());
        var service = new TaxiService(count);
        var flag = true;
        while (flag)
        {
            Console.WriteLine("Select an option to proceed:");
            Console.WriteLine("1. Request a taxi");
            Console.WriteLine("2. View Booking History");
            Console.WriteLine("3. View Taxi Income");
            Console.WriteLine("4. Exit");

            if (!int.TryParse(Console.ReadLine(), out int optionSelected) || optionSelected < 1 || optionSelected > 4)
            {
                Console.WriteLine("Invalid option selected. Please enter a number between 1 and 4.");
            }
            switch (optionSelected)
            {
                case 1:
                    {
                        //methods to request taxi
                        Console.WriteLine("Enter Customer ID:");
                        if (!int.TryParse(Console.ReadLine(), out int customerId))
                        {
                            Console.WriteLine("Invalid Customer ID. Please enter a valid number.");
                            return;
                        }

                        Console.WriteLine("Enter Pickup Point:");
                        string pickupPoint = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(pickupPoint))
                        {
                            Console.WriteLine("Pickup Point cannot be empty.");
                            return;
                        }

                        Console.WriteLine("Enter Drop Point:");
                        string dropPoint = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(dropPoint))
                        {
                            Console.WriteLine("Drop Point cannot be empty.");
                            return;
                        }

                        Console.WriteLine("Enter Pickup Time (in numeric format 0 - 24):");
                        if (!int.TryParse(Console.ReadLine(), out int pickupTime) || pickupTime < 0 || pickupTime > 24)
                        {
                            Console.WriteLine("Invalid Pickup Time. Please enter a valid time in 24-hour format (e.g., 1330 for 1:30 PM).");
                            return;
                        }

                        service.BookTaxi(pickupPoint, dropPoint, pickupTime, customerId);
                        break;
                    }
                case 2:
                    {
                        //method to view booking history
                        Console.WriteLine("Booking History");
                        var bookingHistory = service.GetBookingHistory();
                        // Print header
                        Console.WriteLine("{0,-12} {1,-12} {2,-20} {3,-20} {4,-20} {5,-20} {6,-10}",
                            "BookingID", "CustomerID", "From", "To", "PickupTime", "DropTime", "Amount");

                        // Print entries
                        foreach (var entry in bookingHistory)
                        {
                            Console.WriteLine("{0,-12} {1,-12} {2,-20} {3,-20} {4,-20} {5,-20} {6,-10}",
                                entry.BookingId, entry.CustomerId, entry.PickupPoint.Name, entry.DropPoint.Name,
                                entry.pickupTime, entry.dropTime, entry.Fare);
                        }

                        break;
                    }
                case 3:
                    {
                        //view taxi income.
                        Console.WriteLine("Provide taxiID:");
                        int.TryParse(Console.ReadLine(), out int custId);
                        var bookingHistory = service.GetBookingHistory(custId);
                        Console.WriteLine("{0,-12} {1,-12} {2,-20} {3,-20} {4,-20} {5,-20} {6,-10}",
                                "BookingID", "CustomerID", "From", "To", "PickupTime", "DropTime", "Amount");

                        // Print entries
                        foreach (var entry in bookingHistory)
                        {
                            Console.WriteLine("{0,-12} {1,-12} {2,-20} {3,-20} {4,-20} {5,-20} {6,-10}",
                                entry.BookingId, entry.CustomerId, entry.PickupPoint.Name, entry.DropPoint.Name,
                                entry.pickupTime, entry.dropTime, entry.Fare);
                        }
                        break;
                    }
                case 4:
                    {
                        flag = false;
                        break;
                    }
                default:
                    {
                        Console.WriteLine($"default wtf");
                        break;
                    }
            }
        }
    }
}



