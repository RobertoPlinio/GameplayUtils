using UnityEngine;
using System;

namespace SystemEnumFlag
{
    [Flags]
    public enum EnumFlags
    {
        Flag1 = 1 << 0,
        Flag2 = 1 << 1,
        Flag3 = 1 << 2,
        Flag4 = 1 << 3,
        Flag5 = 1 << 4
    }

    public class SEF_Sample : MonoBehaviour
    {
        public EnumFlags normalFlags;

        [SingleEnumFlagSelect(EnumType = typeof(EnumFlags))]
        public EnumFlags singleFlag;

        [Space, Header("Only visual results. Treat as read-only")]
        public EnumFlags resultFlag;
        public string resultStatus;

        [ContextMenu("Add single to normal")]
        public void AddSingleToNormal()
        {
            resultFlag = BitMaskOperations.AddFlag(normalFlags, singleFlag);
        }

        [ContextMenu("Remove single from normal")]
        public void RemoveSingleFromNormal()
        {
            resultFlag = BitMaskOperations.RemoveFlag(normalFlags, singleFlag);
        }

        [ContextMenu("Single exists in normal?")]
        public void NormalHasSingle()
        {
            bool result = BitMaskOperations.HasFlag(normalFlags, singleFlag);
            string normalPrint = normalFlags.ToString();
            
            //Just to not print '0' or '-1' when dealing with 'Nothing' and 'Everything'
            if (normalFlags <= 0) 
                normalPrint = "Normal enum"; 

            resultStatus = $"{singleFlag} {(result? "exists" : "does not exist")} in {normalPrint}";
            Debug.Log(resultStatus);   
        }
    }
}
