using System;
using System.Text;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    private double Length
    {
        get { return length; }
        set
        {
            if (value<=0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            this.length = value;
        }
    }
    
    private double Width
    {
        get { return width; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            width = value;
        }
    }
    
    private double Height
    {
        get { return height; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            height = value;
        }
    }

    internal double Volume()
    {
        return this.Height * this.Width * this.Length;
    }
    internal double LateralSurfaceArea()
    {
        return (2 * this.Height * this.Width + 2 * this.Length * this.Height);
    }
    internal double TotalSurfaceArea()
    {
        return (2 * this.Height * this.Width + 2 * this.Length * this.Width + 2 * this.Length * this.Height);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Surface Area - {TotalSurfaceArea():f2}");
        sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}");
        sb.AppendLine($"Volume - {Volume():f2}");

        return sb.ToString();
    }

}

