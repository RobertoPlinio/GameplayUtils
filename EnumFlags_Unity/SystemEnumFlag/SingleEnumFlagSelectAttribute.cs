using System;
using UnityEngine;

namespace SystemEnumFlag
{
    /// <summary>
    /// Original author: Joos van Schaik
    /// https://localjoost.github.io/Making-only-one-entry-of-a-Flag-Enum-selectable-in-the-Unity-Editor/
    /// </summary>

    public class SingleEnumFlagSelectAttribute : PropertyAttribute
    {
        private Type enumType;

        public Type EnumType
        {
            get => enumType;
            set
            {
                if (value == null)
                {
                    Debug.LogError($"{GetType().Name}: EnumType cannot be null");
                    return;
                }
                if (!value.IsEnum)
                {
                    Debug.LogError($"{GetType().Name}: EnumType is {value.Name} this is not an enum");
                    return;
                }
                enumType = value;
                IsValid = true;
            }
        }

        public bool IsValid { get; private set; }
    }
}