using System;
using System.Collections.Generic;

public abstract class PropertyAsset
{
    // Fields
    public string PropertyCode;
    public double TaxRatePerUnitArea;

    // Constructor
    public PropertyAsset(string code, double taxRate)
    {
        PropertyCode = code;
        TaxRatePerUnitArea = taxRate;
    }

    // Abstract methods
    public abstract double ComputeFootprintArea();

    public abstract double ComputeEnclosurePerimeter();

    // Virtual method
    public virtual double ComputeEstimatedTax()
    {
        return ComputeFootprintArea() * TaxRatePerUnitArea;
    }
}

public class ResidentialLot : PropertyAsset
{
    public double Frontage;
    public double Depth;

    public ResidentialLot(
        string code, double taxRate,
        double frontage, double depth)
        : base(code, taxRate)
    {
        Frontage = frontage;
        Depth = depth;
    }

    public override double ComputeFootprintArea()
    {
        return Frontage * Depth;
    }

    public override double ComputeEnclosurePerimeter()
    {
        return 2 * (Frontage + Depth);
    }
}


public class CircularStorageDepot : PropertyAsset
{
    public double Radius;

    public CircularStorageDepot(
        string code, double taxRate, double radius)
        : base(code, taxRate)
    {
        Radius = radius;
    }

    public override double ComputeFootprintArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override double ComputeEnclosurePerimeter()
    {
        return 2 * Math.PI * Radius;
    }
}


public class TriangularPark : PropertyAsset
{
    public double BaseSpan;
    public double Height;
    public double Side1;
    public double Side2;
    public double Side3;

    public TriangularPark(
        string code, double taxRate,
        double baseSpan, double height,
        double side1, double side2, double side3)
        : base(code, taxRate)
    {
        BaseSpan = baseSpan;
        Height = height;
        Side1 = side1;
        Side2 = side2;
        Side3 = side3;
    }

    public override double ComputeFootprintArea()
    {
        return 0.5 * BaseSpan * Height;
    }

    public override double ComputeEnclosurePerimeter()
    {
        return Side1 + Side2 + Side3;
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter Property Code: ");
        string code = Console.ReadLine();

        Console.Write("Enter Tax Rate: ");
        double taxRate = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Base Span: ");
        double baseSpan = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Height: ");
        double height = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Side 1: ");
        double side1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Side 2: ");
        double side2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Side 3: ");
        double side3 = Convert.ToDouble(Console.ReadLine());

        PropertyAsset park = new TriangularPark(
            code, taxRate, baseSpan, height,
            side1, side2, side3
        );

        Console.WriteLine("\nProperty Code: " + park.PropertyCode);
        Console.WriteLine("Area: " +
            park.ComputeFootprintArea().ToString("F2"));
        Console.WriteLine("Perimeter: " +
            park.ComputeEnclosurePerimeter().ToString("F2"));
        Console.WriteLine("Estimated Tax: " +
            park.ComputeEstimatedTax().ToString("F2"));
    }
}
