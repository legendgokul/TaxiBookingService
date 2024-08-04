public class TaxiService
{
    private List<Taxi> taxis = new List<Taxi>(); // keep track of taxi
    private List<Booking> bookingHistory = new List<Booking>();
    private List<Point> travelPoints = new List<Point>();

    public TaxiService(int numberOfTaxis)
    {
        //logic to create numberOfTaxis Taxi
        for (int i = 1; i <= numberOfTaxis; i++)
        {
            var curTaxi = new Taxi();
            curTaxi.TaxiId = taxis.Count() + 1;
            curTaxi.CurrentLocation = new Point("A", 0);
            curTaxi.AvailableTime = 0;
            curTaxi.TotalEarning = 0;
            taxis.Add(curTaxi);
        }
        initializePoint();
    }

    public void initializePoint()
    {
        travelPoints.Add(new Point("A", 0));
        travelPoints.Add(new Point("B", 15));
        travelPoints.Add(new Point("C", 30));
        travelPoints.Add(new Point("D", 45));
        travelPoints.Add(new Point("E", 60));
        travelPoints.Add(new Point("F", 75));
    }

    public Taxi FindAvailableTaxi(Point pickupPoint, int bookingTime)
    {

        var availableTaxi = taxis.Where(x => x.AvailableTime <= bookingTime).ToList();//filter available taxi
        if (availableTaxi.Count == 0)
        {
            return new Taxi();
        }

        /*
        point has distance from A, and with that we reduce 15 to find a nearby radius and with this we find list of all availabe taxi
        similarly we do till we find nearby taxi with less income.``
        */
        var scanDistance = 0;
        while (scanDistance <= 75)
        {
            //filter taxi within scanDistance.
            var localTaxi = availableTaxi.Where(x => x.CurrentLocation.DistanceFromA == (pickupPoint.DistanceFromA - scanDistance) ||
            x.CurrentLocation.DistanceFromA == (pickupPoint.DistanceFromA + scanDistance)
            ).OrderBy(x => x.TotalEarning).ToList();
            if (localTaxi.Any())
            {
                return localTaxi.First();
            }
            scanDistance += 15;
        }
        return new Taxi();
    }

    public Boolean BookTaxi(string pickupPoint, string dropPoint, int bookingTime, int custID)
    {
        try
        {
            var curBooking = new Booking();
            curBooking.BookingId = bookingHistory.Count() + 1;
            curBooking.PickupPoint = travelPoints.Where(x => x.Name == pickupPoint).FirstOrDefault();
            curBooking.DropPoint = travelPoints.Where(x => x.Name == dropPoint).FirstOrDefault(); ;
            curBooking.CustomerId = custID;
            curBooking.pickupTime = bookingTime;
            curBooking.dropTime = bookingTime + Math.Abs((curBooking.PickupPoint.DistanceFromA - curBooking.DropPoint.DistanceFromA) / 15);
            curBooking.CalculateFare();
            var taxi = FindAvailableTaxi(curBooking.PickupPoint, bookingTime);
            if (taxi == null)
            {
                Console.WriteLine("No available taxi");
            }
            else
            {
                curBooking.AssignedTaxiID = taxi.TaxiId;
                bookingHistory.Add(curBooking);
                //updating taxi information.
                taxi.AvailableTime = curBooking.dropTime;
                taxi.CurrentLocation = curBooking.DropPoint;
                taxi.TotalEarning += curBooking.Fare;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return true;
    }

    public List<Taxi> GetAllTaxis()
    {
        return taxis;
    }

    public List<Booking> GetBookingHistory()
    {
        return bookingHistory;
    }

    public List<Booking> GetBookingHistory(int taxiId)
    {
        return bookingHistory.Where(x => x.AssignedTaxiID == taxiId).ToList();
    }
}
