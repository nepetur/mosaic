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

        protected virtual void SetVisible(bool value) => visible = value;
        [Space] public bool visible;

        protected float visualAnimation;

        const float animationSpeed = 2;

        void Update(){
            visualAnimation = Mathf.MoveTowards(visualAnimation, visible ? 1 : 0, Time.deltaTime * animationSpeed);

            UpdateVisual();
        }

        protected abstract void UpdateVisual();
    }
}