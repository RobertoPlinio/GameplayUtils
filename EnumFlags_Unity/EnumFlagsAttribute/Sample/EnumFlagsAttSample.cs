using UnityEngine;
using System;

namespace EnumFlags
{
    public class EnumFlagsAttSample : MonoBehaviour
    {
        public enum EnumFlags
        {
            Flag1 = 1 << 0,
            Flag2 = 1 << 1,
            Flag3 = 1 << 2,
            Flag4 = 1 << 3,
            Flag5 = 1 << 4
        }

        [EnumFlags]
        public EnumFlags multipleFlags;

        public EnumFlags singleFlag;

        [EnumFlags, Space, Header("Only visual results. Treat as read-only")]
        public EnumFlags resultFlag;
        public string resultStatus;

        [ContextMenu("Add single to multiple")]
        public void AddSingleToMultiple()
        {
            resultFlag = BitMaskOperations.AddFlag(multipleFlags, singleFlag);
        }

        [ContextMenu("Remove single from multiple")]
        public void RemoveSingleFromMultiple()
        {
            resultFlag = BitMaskOperations.RemoveFlag(multipleFlags, singleFlag);
        }

        [ContextMenu("Single exists in multiple?")]
        public void MultipleHasSingle()
        {
            bool result = BitMaskOperations.HasFlag(multipleFlags, singleFlag);

            string multiplePrint;
            if (multipleFlags <= 0)
            {
                //Just to not print '0' or '-1' when dealing with 'Nothing' and 'Everything'
                multiplePrint = "Multiple enum";
            }
            else
            {
                //In this case, using 'multipleFlags.ToString();' only returns int
                multiplePrint = GetMultipleValuesString();
            }

            resultStatus = $"{singleFlag} {(result ? "exists" : "does not exist")} in {multiplePrint}";
            Debug.Log(resultStatus);
        }

        private string GetMultipleValuesString()
        {
            string result = "";

            var values = Enum.GetValues(typeof(EnumFlags));

            foreach (var value in values)
            {
                if(BitMaskOperations.HasFlag(multipleFlags, (EnumFlags)value))
                {
                    result += $"{value} ";
                }
            }

            return result;
        }
    }
}
