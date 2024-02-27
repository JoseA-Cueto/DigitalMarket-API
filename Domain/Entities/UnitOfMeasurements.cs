using System.Diagnostics;

namespace DigitalMarket_API.Domain.Entities
{
    public enum UnitOfMeasurement
    {
        Unit,
        Gram,
        Liter,
    }

    public static class UnitOfMeasurements
    {
        public static string AsString(this UnitOfMeasurement unit)
        {
            return unit switch
            {
                UnitOfMeasurement.Unit => "U",
                UnitOfMeasurement.Liter => "L",
                UnitOfMeasurement.Gram => "G",
                _ => throw new UnreachableException("Invalid Unit Of Measurement. This should have been never thrown")
            };
        }

        public static UnitOfMeasurement FromString(string s)
        {
            return s switch
            {
                "U" or "u" => UnitOfMeasurement.Unit,
                "L" or "l" => UnitOfMeasurement.Liter,
                "G" or "g" => UnitOfMeasurement.Gram,
                _ => throw new ArgumentException($"'{s}' is not a valid unit of measurement")
            };
        }
    }
}
