using UnityEngine;

namespace Mosaic{
    public abstract class VisualElement : MonoBehaviour{
        protected RectTransform rectTransform => transform as RectTransform;

        protected virtual void Start(){
            SetVisible(visible);

            visualAnimation = visible ? 1 : 0;

            UpdateVisual();
        }

        public void Show() => SetVisible(true);
        public void Hide() => SetVisible(false);

        protected virtual void SetVisible(bool value){
            visible = value;

            switch(visualAnimation){
                case 1:
                    enabled = true;
                    break;
                case 0:
                    gameObject.SetActive(true);
                    break;
            }
        }
        [Space] public bool visible;

        protected float visualAnimation;

        private const float animationSpeed = 2;

        private void Update(){
            visualAnimation = Mathf.MoveTowards(visualAnimation, visible ? 1 : 0, Time.deltaTime * animationSpeed);

            UpdateVisual();

            switch(visualAnimation){
                case 1:
                    enabled = false;
                    break;
                case 0:
                    gameObject.SetActive(false);
                    break;
            }
        }

        protected abstract void UpdateVisual();
    }
}