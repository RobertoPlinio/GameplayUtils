using System;

namespace EnumFlags
{
    public static class BitMaskOperations
    {
        public static T AddFlag<T>(T baseFlag, T addedFlag) where T : Enum
        {
            int a = (int)(object)baseFlag;
            int b = (int)(object)addedFlag;
            int result = a |= b;

            return (T)Enum.Parse(typeof(T), result.ToString());
        }

        public static T RemoveFlag<T>(T baseFlag, T removedFlag) where T : Enum
        {
            int a = (int)(object)baseFlag;
            int b = (int)(object)removedFlag;
            int result = a &= ~b;

            return (T)Enum.Parse(typeof(T), result.ToString());
        }

        public static bool HasFlag<T>(T baseFlag, T compareFlag) where T : Enum
        {
            int a = (int)(object)baseFlag;
            int b = (int)(object)compareFlag;


            return (a & b) != 0;
        }
    }
}
