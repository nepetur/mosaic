using TMPro;
using UnityEngine;

namespace Mosaic{
    public class NumberSelector : MonoBehaviour{
        [Space, SerializeField] TextMeshProUGUI text;

        [Space, SerializeField, TextArea] string prompt;

        void Start() => UpdateText(1);

        public void UpdateText(float value){
            value = Mathf.RoundToInt(value);

            text.text = string.Format(prompt, value);
        }
    }
}