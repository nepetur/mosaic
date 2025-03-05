using UnityEngine;

namespace Mosaic{
    public class ColorPalette : FieldGenerator{
        [Space, SerializeField] private Color[] colors;

        public void SetLength(float value) => width = Mathf.RoundToInt(value + 1);

        public override void Generate(){
            base.Generate();
            
            var count = 0;

            foreach(var tile in tiles){
                tile.SpriteRenderer.color = colors[count];

                tile.gameObject.tag = tag;

                count++;
            }
        }
    }
}