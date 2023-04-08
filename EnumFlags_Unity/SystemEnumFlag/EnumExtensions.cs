using System;

namespace SystemEnumFlag
{
    public static class EnumExtensions
    {
        /// <summary>
        /// A better way to check validity of an enum. Works with the System.Flags att whereas Enum.IsDefined does not
        /// Original author: joshcomley
        /// https://stackoverflow.com/questions/2674730/is-there-a-way-to-check-if-int-is-legal-enum-in-c
        /// </summary>
        public static bool IsValid<TEnum>(this TEnum enumValue) where TEnum : Enum
        {
            var firstChar = enumValue.ToString()[0];
            return (firstChar < '0' || firstChar > '9') && firstChar != '-';
        }
    }
}
