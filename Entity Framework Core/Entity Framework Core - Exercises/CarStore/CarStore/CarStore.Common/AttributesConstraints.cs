using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.Common
{
    public static class AttributesConstraints
    {
        #region Car
        public const int MakeMaxLength = 50;

        public const int ModelMaxLength = 50;

        public const int CarDescriptionMaxLength = 500;

        public const string DecimalMinValue = "0.00";
        
        public const string DecimalMaxValue = "79228162514264337593543950335";

        public const double MileageMaxLength = 500000;

        public const double MileageMinLength = 0;
        #endregion

        #region CarComment
        public const int UserFullNameMaxLength = 100;

        public const int ContentMaxLength = 250;
        #endregion

        #region Engine
        public const short HorsePowerMaxValue = 2000;

        public const short HorsePowerMinValue = 70;

        public const double EngineDisplacementMaxValue = 8.00;

        public const double EngineDisplacementMinValue = 1.00;
        #endregion

        #region User
        public const byte FirstNameMaxValue = 50;

        public const byte LastNameMaxValue = 50;

        public const byte UsernameMaxValue = 50;

        public const byte PhoneMaxLength = 10;

        public const byte EmailMaxLength = 50;
        #endregion
    }
}
