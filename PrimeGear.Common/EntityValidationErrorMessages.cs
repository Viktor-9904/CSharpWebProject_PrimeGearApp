namespace PrimeGearApp.Common
{
    public class EntityValidationErrorMessages
    {
        public static class ProductErrorMessages
        {
            public const string NameIsTooShort = "Name is too short!";
            public const string NameIsTooLong = "Name is too long!";

            public const string BrandIsTooShort = "Brand is too short!";
            public const string BrandIsTooLong = "Brand is too long!";

            public const string PriceIsTooLow = "Price is too low!";
            public const string PriceIsTooHigh = "Brand is too high!";
            public const string PriceNotInRange = "Price not in range!";

            public const string WarrantyMin = "Warranty can't be below 0!";
            public const string WarrantyMax = "Warranty is too high!";
            public const string WarrantyNotInRange = "Warranty not in range!";

            public const string QuantityMin = "Avaible quantity can't be below 0!";
            public const string QuantityMax = "Avaible quantity is too high!";
            public const string QuantityNotInRange = "Quantity not in range!";

        }
    }
}
