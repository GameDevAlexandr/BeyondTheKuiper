using UnityEngine;
using UnityEngine.UI;

namespace Assets.SimpleLocalization.Scripts
{
	/// <summary>
	/// Localize text component.
	/// </summary>
    [RequireComponent(typeof(Text))]
    public class LocalizedText : MonoBehaviour
    {
        public string key { set { _localizationKey = value; Localize(); } }

       [SerializeField] private string _localizationKey;
        private Text _text;
        public void Start()
        {
            Localize();
            LocalizationManager.OnLocalizationChanged += Localize;
        }

        private void InitText()
        {
            if (!_text)
            {
                _text = GetComponent<Text>();
            }
        }
        public void OnDestroy()
        {
            LocalizationManager.OnLocalizationChanged -= Localize;
        }

        private void Localize()
        {
            InitText();
            _text.text = LocalizationManager.Localize(_localizationKey);
            
        }
    }
}