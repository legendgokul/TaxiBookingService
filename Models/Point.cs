public class Point
{
    public Point(string Name, int Distance)
    {
        this.Name = Name;
        this.DistanceFromA = Distance;
    }
    public string Name { get; set; }
    public int DistanceFromA { get; set; } // Distance from point A in kilometers

}