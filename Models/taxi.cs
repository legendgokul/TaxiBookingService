public class Taxi
{
    public int TaxiId {get;set;} //starts from 1 -> n
    public Point CurrentLocation {get;set;} // one of available points
    public int AvailableTime{get;set;}
    public decimal TotalEarning {get;set;} // Total learning done by this taxi.
}
