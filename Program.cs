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
            Console.WriteLine("Select a option to proceed..");
            Console.WriteLine("1.Request a taxi");
            Console.WriteLine("2.View Booking History");
            Console.WriteLine("3.View Taxi Income");
            Console.WriteLine("4.Exit");

            var optionSelected = int.Parse(Console.ReadLine());
            Console.WriteLine($"Selected option :{optionSelected}");
            switch (optionSelected)
            {
                case 1:
                    {
                        //methods to request taxi
                        Console.WriteLine("Customer ID");
                        int.TryParse(Console.ReadLine(), out int custId);

                        Console.WriteLine("Pickup Point");
                        var pickpoint = Console.ReadLine();

                        Console.WriteLine("Drop Point");
                        var droppoint = Console.ReadLine();

                        Console.WriteLine("Pickup Time");
                        int.TryParse(Console.ReadLine(), out int pickuptime);

                        service.BookTaxi(pickpoint, droppoint, pickuptime, custId);
                        break;
                    }
                case 2:
                    {
                        //method to view booking history
                        Console.WriteLine("Booking History");
                        var bookingHistory = service.GetBookingHistory();
                        Console.WriteLine("BookingID    CustomerID    From    To    PickupTime    DropTime    Amount");
                        foreach (var entry in bookingHistory)
                        {
                            Console.WriteLine($"{entry.BookingId} : {entry.CustomerId} : {entry.PickupPoint.Name} : {entry.DropPoint.Name} : {entry.pickupTime} :{entry.dropTime} : {entry.Fare} ");
                        }
                        break;
                    }
                case 3:
                    {
                        //view taxi income.
                        Console.WriteLine("Provide taxiID:");
                        int.TryParse(Console.ReadLine(), out int custId);
                        var bookingHistory = service.GetBookingHistory(custId);
                        Console.WriteLine("BookingID    CustomerID    From    To    PickupTime    DropTime    Amount");
                        foreach (var entry in bookingHistory)
                        {
                            Console.WriteLine($"{entry.BookingId} : {entry.CustomerId} : {entry.PickupPoint.Name} : {entry.DropPoint.Name} : {entry.pickupTime} :{entry.dropTime} : {entry.Fare} ");
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

    /*
    public BookingDetail getBookingDetail()
    {
        BookingDetail BD = new BookingDetail();
        
        BD.bookingId = bookingList.Count+1;
            
        Console.WriteLine("Customer ID :");
        BD.CustomerId = int.Parse(Console.ReadLine());

        Console.WriteLine("Pickup Point :");
        BD.FromLoc = Console.ReadLine();

        Console.WriteLine("Drop Point :");
        BD.ToLoc = Console.ReadLine();

        Console.WriteLine("Pickup Time :");
        BD.pickupTime = int.Parse(Console.ReadLine());

        //calculate amount and dropTime depending on available taxi.
    }
    */

}



