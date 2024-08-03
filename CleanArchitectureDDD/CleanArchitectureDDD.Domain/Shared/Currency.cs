using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureDDD.Domain.Shared
{
    public class Currency
    {
        public string Code { get; } // Código de la moneda (ISO 4217)
        public string Symbol { get; } // Símbolo de la moneda
        public string Name { get; } // Nombre de la moneda

        private Currency(string code, string symbol, string name)
        {
            Code = code;
            Symbol = symbol;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name} ({Code})";
        }

        // Definición de monedas comunes como propiedades estáticas
        public static readonly Currency USD = new Currency("USD", "$", "US Dollar");
        public static readonly Currency EUR = new Currency("EUR", "€", "Euro");
        public static readonly Currency MXN = new Currency("MXN", "$", "Mexican Peso");
        public static readonly Currency GBP = new Currency("GBP", "£", "British Pound");
        public static readonly Currency JPY = new Currency("JPY", "¥", "Japanese Yen");
        public static readonly Currency NONE = new Currency("UNKNOW", "UNKNOW", "UNKNOW");

        // Método para obtener una moneda por su código
        public static Currency FromCode(string code)
        {
            return code.ToUpper() switch
            {
                "USD" => USD,
                "EUR" => EUR,
                "MXN" => MXN,
                "GBP" => GBP,
                "JPY" => JPY,
                _ => throw new ArgumentException($"Unknown currency code: {code}")
            };
        }
    }
}