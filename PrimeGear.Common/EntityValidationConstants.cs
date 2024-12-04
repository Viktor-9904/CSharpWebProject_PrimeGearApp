using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeGearApp.Common
{
    public static class EntityValidationConstants
    {
        public static class ProductConstants
        {
            public const int ProductNameMinLength = 2;
            public const int ProductNameMaxLength = 200;

            public const int ProductBrandMinLength = 2;
            public const int ProductBrandMaxLength = 200;

            public const int ProductDescriptionMinLength = 10;
            public const int ProductDescriptionMaxLength = 1000;

            public const string ProductReleaseDateFormat = "dd-MM-yyyy";

            public const decimal ProductMinPrice = 0.01m;
            public const decimal ProductMaxPrice = 999999999999999999m;

            public const double ProductMinWeigth = 0.01d; 
            public const double ProductMaxWeigth = 999999999d;

            public const int ProductMinWarrantyDurationInMonths = 0;
            public const int ProductMaxWarrantyDurationInMonths = 2400;

            public const int ProductMinAvaibleQuantity = 0;
            public const int ProductMaxAvaibleQuantity = 999999;
        }
        public static class ProductTypeConstants
        {
            public const int ProductTypeNameMinLength = 3;
            public const int ProductTypeNameMaxLength = 100;
        }

        public static class ProductDetailsConstants
        {
            public const int ProductTypePropertyValueMinLength = 1;
            public const int ProductTypePropertyValueMaxLength = 200;
        }
        public static class ProductTypePropertyConstants
        {
            public const int ProductTypePropertyUnitMinLength = 1;
            public const int ProductTypePropertyUnitMaxLength = 100;

            public const int ProductTypePropertyNameMinLength = 3;
            public const int ProductTypePropertyNameMaxLength = 200;
        }
        public static class PropertyValueTypeConstants
        {
            public const int PropertyValueTypeNameMinLength = 3;
            public const int PropertyValueTypeNameMaxLength = 100;
        }
        public static class ManagerConstants
        {
            public const int ManagerWorkPhoneMinLenght = 5;
            public const int ManagerWorkPhoneMaxLenght = 15;
        }
    }
}
