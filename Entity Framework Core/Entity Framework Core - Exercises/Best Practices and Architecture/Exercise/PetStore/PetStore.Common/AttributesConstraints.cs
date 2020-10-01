using System;

namespace PetStore.Common
{
    public static class AttributesConstraints
    {
        public const byte PetNameMaxLength = 10;
        public const byte PetAgeMaxValue = 10;
        public const string PriceMinValue = "0.00";
        public const string PriceMaxValue = "79228162514264337593543950335";
        public const byte ProdudctNameMaxValue = 20;
        public const byte OrderTownNameMaxLength = byte.MaxValue;
        public const byte OrderAddressNameMaxLength = byte.MaxValue;
        public const byte OrderNotesMaxValue = byte.MaxValue;
        public const byte UsernameameMaxLength = 50;
        public const byte PasswordMaxLength = byte.MaxValue;
        public const byte EmailMaxLength = 32;
        public const byte FirstNameMaxLength = 20;
        public const byte LastNameMaxLength = 20;
        public const byte BreedNameMaxLength = 50;
    }
}
