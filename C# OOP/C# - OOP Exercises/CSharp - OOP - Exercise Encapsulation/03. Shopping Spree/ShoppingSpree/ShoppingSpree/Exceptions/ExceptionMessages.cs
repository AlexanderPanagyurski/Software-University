using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree.Exceptions
{
    public static class ExceptionMessages
    {
        private const string DefaultNameException = "Name cannot be empty";
        private const string DefaultMoneyException = "Money cannot be negative";
        private const string DefaultEmptyProductsCollectionException = "{0} - Nothing bought";
        private const string DefaultNotEnoughMoneyException = "{0} can't afford {1}";

        public static string NameException { get => DefaultNameException; }
        public static string MoneyException { get => DefaultMoneyException; }

        public static string EmptyProductsCollectionException { get => DefaultEmptyProductsCollectionException; }

        public static string NotEnoughMoneyException { get => DefaultNotEnoughMoneyException; }
    }
}
