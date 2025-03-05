using TMPro;
using UnityEngine;

namespace Mosaic{
    public class NumberSelector : MonoBehaviour{
        [Space, SerializeField] private TextMeshProUGUI text;

        [Space, SerializeField, TextArea] private string prompt;

        private void Start() => UpdateText(1);

        public void UpdateText(float value){
            value = Mathf.RoundToInt(value);

            text.text = string.Format(prompt, value);
        }
    }
}