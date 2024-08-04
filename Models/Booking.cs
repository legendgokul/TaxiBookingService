public class Booking
{
    public int BookingId { get; set; }
    public int CustomerId { get; set; }
    public Point PickupPoint { get; set; }
    public Point DropPoint { get; set; }
    public decimal Fare { get; set; }
    public int pickupTime { get; set; }
    public int dropTime { get; set; }
    public int AssignedTaxiID { get; set; }

    // Methods
    public void CalculateFare()
    {
        this.Fare = ((this.DropPoint.DistanceFromA - this.PickupPoint.DistanceFromA - 5) * 10) + 100;
    }
}
