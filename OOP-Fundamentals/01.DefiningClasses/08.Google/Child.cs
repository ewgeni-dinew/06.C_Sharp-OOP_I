public class Child
{
    public string Name { get;private set; }
    public string Birth { get; private set; }

    public Child(string name,string birth)
    {
        this.Birth = birth;
        this.Name = name;
    }
}