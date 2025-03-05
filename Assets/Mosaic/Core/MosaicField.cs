using UnityEngine;
using System.IO;
using System;
using Unity.Collections;
using System.Collections;

namespace Mosaic{
    public class MosaicField : FieldGenerator{
        public void SaveImage(){
            if(tiles.Count == 0) return;

            StartCoroutine( Save() );
        }

        private IEnumerator Save(){
            yield return new WaitForEndOfFrame();

            var offset = Vector3.right / 2;

            Vector3 first = Camera.main.WorldToScreenPoint(tiles[0].transform.position - offset), last = Camera.main.WorldToScreenPoint(tiles[^1].transform.position);

            int w = (int)Mathf.Abs(first.x - last.x), h = (int)Mathf.Abs(first.y - last.y);

            var tex = new Texture2D(w, h, TextureFormat.RGB24, false);
            tex.ReadPixels(
                new Rect(first.x, last.y, w, h), 0, 0
            );
            tex.Apply();

            var image = new NativeArray<byte>(tex.GetRawTextureData(), Allocator.Temp);
            var bytes = ImageConversion.EncodeNativeArrayToPNG(image, tex.graphicsFormat, (uint)w, (uint)h);

            Destroy(tex);

            var directory = Directory.CreateDirectory(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Mosaic")
            );

            File.WriteAllBytes(
                Path.Combine(directory.FullName, "file.png"), bytes.ToArray()
            );
        }
    }
}