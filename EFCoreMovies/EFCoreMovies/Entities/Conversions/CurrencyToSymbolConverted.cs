using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreMovies.Entities.Conversions
{
    public class CurrencyToSymbolConverted: ValueConverter<Currency, string>
    {
        public CurrencyToSymbolConverted() : base(
                value => MapCurrencyString(value),
                value => MapStringToCurrency(value)
            )
        {
            
        }

        /// <summary>
        /// Map from currency enum to string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string MapCurrencyString(Currency value)
        {
            return value switch
            {
                Currency.Pesos => "$MXN",
                Currency.USDollar => "$US",
                Currency.Euro => "€EURO",
                _ => ""
            };
        }

        /// <summary>
        /// Map from string to currency enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static Currency MapStringToCurrency(string value)
        {
            return value switch
            {
                "$MXN" => Currency.Pesos,
                "$US" => Currency.USDollar,
                "€EURO" => Currency.Euro,
                _ => Currency.Unknow
            };
        }
    }
}
