using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionSolution.Persistence.Extensions
{
    public static class GenericExtensions
    {
        /// <summary>
        /// An extension method that returns whether string is empty, null or white space.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>String is empty, null or white space.</returns>
        public static bool IsNullOrEmptyOrWhiteSpace(this string? value)
            => string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// An extension method that returns whether string is not empty, null or white space.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>String is not empty, null or white space.</returns>
        public static bool IsNotNullOrEmptyOrWhiteSpace(this string value)
            => !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// Json Deserialize String -> Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="text"></param>
        /// <returns></returns>
        public static T? Deserialize<T>(this string text)
            => JsonConvert.DeserializeObject<T>(text);

        /// <summary>
        /// Json Serialize Object -> String
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Serialize<T>(this T value)
            => JsonConvert.SerializeObject(value) ?? string.Empty;
    }
}
