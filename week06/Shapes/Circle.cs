public class Circle : Shape
{
    private double _radius;

    public Circle(string color, double radius) : base (color)
    {
        _radius = radius;
    }

    // using the override keyword here
    public override double GetArea()
    {
        return _radius * _radius * Math.PI;
    }
}