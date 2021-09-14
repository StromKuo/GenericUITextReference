using UnityEngine;
using UnityEditor;

namespace SKUnityToolkit.GenericUITextReference
{
    [CustomPropertyDrawer(typeof(TextReference), true)]
    public class TextReferenceDrawer : PropertyDrawer
    {
        private readonly string[] popupOptions = { "Text", "TextMeshPro - Text(UI)" };

        private GUIStyle popupStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (popupStyle == null)
            {
                popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
                popupStyle.imagePosition = ImagePosition.ImageOnly;
            }

            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            // Get properties
            SerializedProperty textType = property.FindPropertyRelative("_textType");
            SerializedProperty textUI = property.FindPropertyRelative("_textUI");
            SerializedProperty textMeshProUI = property.FindPropertyRelative("_textMeshProUI");

            // Calculate rect for configuration button
            Rect buttonRect = new Rect(position);
            buttonRect.yMin += popupStyle.margin.top;
            buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
            position.xMin = buttonRect.xMax;

            // Store old indent level and set it to 0, the PrefixLabel takes care of it
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            textType.enumValueIndex = EditorGUI.Popup(buttonRect, textType.enumValueIndex, popupOptions, popupStyle);

            if ((TextType)textType.enumValueIndex == TextType.Text)
            {
                EditorGUI.PropertyField(position, textUI, GUIContent.none);
            }
            else
            {
                EditorGUI.PropertyField(position, textMeshProUI, GUIContent.none);
            }

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }
}