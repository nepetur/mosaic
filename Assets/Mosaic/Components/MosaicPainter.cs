using UnityEngine;

namespace Mosaic{
    public class MosaicPainter : MonoBehaviour{
        Color selectedColor = Color.white;
        static public PopUpTile Pointed {get; private set;}

        void Update(){
            SearchForTile();

            if(Pointed == false) return;

            if(canPaint){
                Paint();

                tileClicked = true;
            }
        }

        void Paint(){
            Pointed.OnClick();

            if( Pointed.CompareTag("ColorTile") ){
                selectedColor = Pointed.SpriteRenderer.color;
            }
            else{
                Pointed.SpriteRenderer.color = selectedColor;
            }
        }

        bool canPaint => click || (hold && !tileClicked);

        bool hold => Input.GetMouseButton(0);
        bool tileClicked;
        bool click => Input.GetMouseButtonDown(0);

        public void SearchForTile(){
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            var raycast = Physics2D.Raycast(ray.origin, ray.direction);

            var tile = raycast ? raycast.transform.GetComponentInParent<PopUpTile>() : null;

            if(Pointed == tile) return;

            Pointed = tile;

            tileClicked = false;
        }
    }
}