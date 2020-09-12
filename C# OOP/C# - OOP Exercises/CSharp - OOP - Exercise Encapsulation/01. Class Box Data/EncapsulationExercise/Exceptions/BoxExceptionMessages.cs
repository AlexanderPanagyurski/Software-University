using System;
using System.Collections.Generic;
using System.Text;

namespace EncapsulationExercise.Exceptions
{
    public static class BoxExceptionMessages
    {
        private const string DefaultLengthExceptionMessage = "Length cannot be zero or negative.";
        private const string DefaultWidthExceptionMessage = "Width cannot be zero or negative.";
        private const string DefaultHeightExceptionMessage = "Height cannot be zero or negative.";

        public static string LengthExceptionMessage => DefaultLengthExceptionMessage;
        public static string WidthExceptionMessage => DefaultWidthExceptionMessage;
        public static string HeightExceptionMessage => DefaultHeightExceptionMessage;

    }
}
