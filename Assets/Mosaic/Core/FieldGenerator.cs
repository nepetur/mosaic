using System.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace Mosaic{
    public class FieldGenerator : MonoBehaviour{
        [Space, SerializeField] protected int height, width;

        [Space, SerializeField] private PopUpTile tilePrefab;

        protected List<PopUpTile> tiles = new();

        private float CalculateOffset(int parameter) => parameter % 2 == 0 ? parameter / 2 - .5f : parameter / 2;

        public virtual void Generate(){
            float gridOffsetX = CalculateOffset(width), gridOffsetY = CalculateOffset(height);
            
            for(int i = 0; i < height; i++){
                var rowOffset = height == 1 ? 0 : (i % 2 == 0 ? 1 : -1) * .25f;

                for(int j = 0; j < width; j++){
                    var tile = Instantiate(tilePrefab, transform);

                    tiles.Add(tile);

                    #if UNITY_EDITOR
                        tile.name = $"{i}-{j}";
                    #endif

                    tile.transform.localPosition = new Vector2(j + rowOffset - gridOffsetX, (-i + gridOffsetY) * .75f);
                }
            }

            StartCoroutine( DelayedActivation() );
        }

        private IEnumerator DelayedActivation(){
            var delay = 1.5f / tiles.Count;

            foreach(var tile in tiles){
                yield return new WaitForSecondsRealtime(delay);

                tile.gameObject.SetActive(true);
            }
        }

        #if UNITY_EDITOR
        private void OnDrawGizmos(){
            Gizmos.DrawWireCube(
                transform.position, new Vector2(height == 1 ? width : width + .5f, height * .75f)
            );
        }
        #endif
    }
}