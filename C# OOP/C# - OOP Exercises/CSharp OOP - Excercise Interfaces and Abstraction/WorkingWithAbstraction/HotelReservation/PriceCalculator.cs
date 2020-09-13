using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    static class PriceCalculator
    {
        public static double Calculate(double pricePerDay, int daysCount, string season)
        {
            if (season == "Autumn")
            {
                pricePerDay *= 1;
            }
            else if (season == "Spring")
            {
                pricePerDay *= 2;
            }
            else if (season == "Winter")
            {
                pricePerDay *= 3;
            }
            else if (season == "Summer")
            {
                pricePerDay *= 4;
            }
            pricePerDay *= daysCount;

            return pricePerDay;
        }
        public static double Calculate(double pricePerDay, int daysCount, string season, string discountType)
        {
            if (season == "Autumn")
            {
                pricePerDay *= 1;
            }
            else if (season == "Spring")
            {
                pricePerDay *= 2;
            }
            else if (season == "Winter")
            {
                pricePerDay *= 3;
            }
            else if (season == "Summer")
            {
                pricePerDay *= 4;
            }
            pricePerDay *= daysCount;
            if (discountType == "VIP")
            {
                pricePerDay *= 0.80;
            }
            else if (discountType == "SecondVisit")
            {
                pricePerDay *= 0.90;
            }
            return pricePerDay;
        }
    }
}
