using UnityEngine;

namespace Mosaic{
    public class PopUpElement : VisualElement{
        CanvasGroup canvasGroup;

        void Awake(){
            canvasGroup = GetComponent<CanvasGroup>();
        }

        const float scaleAnimationDelta = 1.25f;

        protected override void SetVisible(bool value){
            base.SetVisible(value);

            canvasGroup.interactable = value;
        }

        protected override void UpdateVisual(){
            var scale = 1 + (scaleAnimationDelta + 1) * Mathf.Pow(visualAnimation - 1, 3) + scaleAnimationDelta * Mathf.Pow(visualAnimation - 1, 2);

            canvasGroup.alpha = 1 + Mathf.Pow(visualAnimation - 1, 3) * Mathf.Pow(visualAnimation - 1, 2);

            transform.localScale = Vector3.one * scale;
        }
    }
}