using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace EnumFlags
{
    /// <summary>
    /// Original author: froodydude
    /// https://answers.unity.com/questions/486694/default-editor-enum-as-flags-.html
    /// </summary>
    public class EnumFlagsAttribute : PropertyAttribute
    {
        public EnumFlagsAttribute() { }
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(EnumFlagsAttribute))]
    public class EnumFlagsAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
        {
            _property.intValue = EditorGUI.MaskField(_position, _label, _property.intValue, _property.enumNames);
        }
    }
#endif
}
