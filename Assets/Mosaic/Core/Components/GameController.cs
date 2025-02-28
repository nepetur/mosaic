using UnityEngine;
using System;
using UnityEngine.EventSystems;

namespace Mosaic{
    public class GameController : MonoBehaviour{
        [Serializable] public struct Components{
            public AudioSource audioSource;
        }
        [Space] public Components components;

        [Space, SerializeField] Texture2D pointerCursor;

        void Update(){
            ChangeCursor();
        }

        bool isPointer;
        bool GetCurrentCursor() => MosaicPainter.Pointed || (EventSystem.current && EventSystem.current.IsPointerOverGameObject());

        void ChangeCursor(){
            var currentCursor = GetCurrentCursor();

            if(currentCursor == isPointer) return;

            isPointer = currentCursor;

            if(isPointer){
                Cursor.SetCursor(pointerCursor, Vector2.right * 10, CursorMode.Auto);
            }
            else Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}