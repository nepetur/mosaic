using UnityEngine;

namespace Mosaic{
    public class MosaicPainter : MonoBehaviour{
        private Camera mainCamera;
        private Color selectedColor = Color.white;
        private PopUpTile currentTile;

        [Space, SerializeField] private ColorPalette colorPalette;

        private void Start(){
            mainCamera = Camera.main;
        }

        private void Update(){
            if(click || hold){
                SearchForTile();

                if(currentTile && !tileClicked) Paint();
            }
        }

        private void Paint(){
            currentTile.OnClick();

            tileClicked = true;

            if( currentTile.CompareTag(colorPalette.tag) ){
                selectedColor = currentTile.SpriteRenderer.color;
            }
            else{
                currentTile.SpriteRenderer.color = selectedColor;
            }
        }

        private bool hold => Input.GetMouseButton(0);
        private bool tileClicked;
        private bool click => Input.GetMouseButtonDown(0);

        private void SearchForTile(){
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            var raycast = Physics2D.Raycast(ray.origin, ray.direction);

            var tile = raycast ? raycast.transform.GetComponentInParent<PopUpTile>() : null;

            if(tile == currentTile) return;

            currentTile = tile;

            tileClicked = false;
        }
    }
}