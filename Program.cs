using System;

namespace Money
{
    public class Currency
    {
        public string Code;
        public double Rate;

        public Currency(string code, double rate)
        {
            Code = code;
            Rate = rate;
        }

        public double Convert(double amount, Currency toCurrency)
        {
            return Math.Round(amount * toCurrency.Rate / Rate, 2);
        }
    }

    internal class CurrencyConverter
    {
        static void Main()
        {
            Console.OutputEncoding = Console.InputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine("Введіть Вашу валюту (USD, EUR, UAH, PLN):");
            string fromCode = Console.ReadLine().ToUpper();

            Console.WriteLine("Введіть Вашу суму:");
            double startMoney = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Оберіть валюту для конвертації:");
            string toCode = Console.ReadLine().ToUpper();

            Currency usd = new Currency("USD", 1.00);
            Currency eur = new Currency("EUR", 0.93);
            Currency uah = new Currency("UAH", 35.98);
            Currency pln = new Currency("PLN", 4.13);

            Currency fromCurrency = GetCurrencyByCode(fromCode, usd, eur, uah, pln);
            Currency toCurrency = GetCurrencyByCode(toCode, usd, eur, uah, pln);

            double result = fromCurrency.Convert(startMoney, toCurrency);

            Console.WriteLine($"Успішна конвертація з {fromCurrency.Code} у {toCurrency.Code}!");
            Console.WriteLine($"У Вас є {result} {toCurrency.Code}!");
        }

        private static Currency GetCurrencyByCode(string code, params Currency[] currencies)
        {
            foreach (var currency in currencies)
            {
                if (currency.Code == code)
                    return currency;
            }
            throw new ArgumentException("Invalid currency code");
        }
    }
}
