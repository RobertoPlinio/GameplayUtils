using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace SystemEnumFlag
{
    /// <summary>
    /// Original author: Joos van Schaik
    /// https://localjoost.github.io/Making-only-one-entry-of-a-Flag-Enum-selectable-in-the-Unity-Editor/
    /// </summary>

    [CustomPropertyDrawer(typeof(SingleEnumFlagSelectAttribute))]
    public class SingleEnumFlagAttributeEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position,
      SerializedProperty property, GUIContent label)
        {
            var singleEnumFlagSelectAttribute =
              (SingleEnumFlagSelectAttribute)attribute;
            if (!singleEnumFlagSelectAttribute.IsValid)
            {
                return;
            }
            var displayTexts = new List<GUIContent>();
            var enumValues = new List<int>();
            foreach (var displayText in
              Enum.GetValues(singleEnumFlagSelectAttribute.EnumType))
            {
                displayTexts.Add(new GUIContent(displayText.ToString()));
                enumValues.Add((int)displayText);
            }

            property.intValue = EditorGUI.IntPopup(position, label, property.intValue,
                displayTexts.ToArray(), enumValues.ToArray());
        }
    }
}