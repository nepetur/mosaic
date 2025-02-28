using System.Collections;
using UnityEngine;

namespace Mosaic{
    public class PopUpTile : MonoBehaviour{
        [SerializeField] SpriteRenderer spriteRenderer;
        public SpriteRenderer SpriteRenderer => spriteRenderer;

        IEnumerator Start(){            
            for(float time = 0; time < 1; time += Time.deltaTime * 2){
                transform.localScale = Vector3.one * time;

                yield return null;
            }
        }

        public void OnClick(){
            enabled = true;

            clickAnimation = 1;
        }

        const float animationSpeed = 2.5f;
        float clickAnimation;
        void Update(){
            clickAnimation = Mathf.MoveTowards(clickAnimation, 0, Time.deltaTime * animationSpeed);

            transform.GetChild(0).localScale = Vector3.one * (1 - .15f * Mathf.Sin(Mathf.PI * clickAnimation));

            if(clickAnimation == 0) enabled = false;
        }
    }
}