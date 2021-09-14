using UnityEngine;

namespace SKUnityToolkit.GenericUITextReference
{
    [System.Serializable]
    public class TextReference
    {
        public TextType textType  => this._textType;

        public UnityEngine.UI.Text textUI => this._textUI;

        public TMPro.TextMeshProUGUI textMeshProUI => this._textMeshProUI;

        [SerializeField]
        TextType _textType;

        [SerializeField]
        UnityEngine.UI.Text _textUI;

        [SerializeField]
        TMPro.TextMeshProUGUI _textMeshProUI;

        public string text
        {
            get
            {
                return this._textType == TextType.Text ? this._textUI.text : this._textMeshProUI.text;
            }
            set
            {
                if (this._textType == TextType.Text)
                {
                    this._textUI.text = value;
                }
                else
                {
                    this._textMeshProUI.text = value;
                }
            }
        }

        public GameObject gameObject
        {
            get
            {
                return this._textType == TextType.Text ? this._textUI.gameObject : this._textMeshProUI.gameObject;
            }
        }
    }

    public enum TextType
    {
        Text,
        TextMeshProUGUI
    }
}