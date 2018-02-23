public class Car
{
    public string Model { get; private set; }
    public string Speed { get; private set; }

    public Car(string model,string speed)
    {
        this.Model = model;
        this.Speed = speed;
    }
}