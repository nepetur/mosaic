using UnityEngine;
using System.Collections;

namespace Mosaic{
    public class PopUpTile : MonoBehaviour{
        [Space, SerializeField] private SpriteRenderer spriteRenderer;
        public SpriteRenderer SpriteRenderer => spriteRenderer;

        private IEnumerator Start(){            
            for(float time = 0; time < 1; time += Time.deltaTime * 2){
                transform.localScale = Vector3.one * time;

                yield return null;
            }
        }

        public void OnClick(){
            enabled = true;

            clickAnimation = 1;
        }

        private const float animationSpeed = 3f;
        private float clickAnimation;
        private void Update(){
            clickAnimation = Mathf.MoveTowards(clickAnimation, 0, Time.deltaTime * animationSpeed);

            transform.GetChild(0).localScale = Vector3.one * (1 - .075f * Mathf.Sin(Mathf.PI * clickAnimation));

            if(clickAnimation == 0) enabled = false;
        }
    }
}