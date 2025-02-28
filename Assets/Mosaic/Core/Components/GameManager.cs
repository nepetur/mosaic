using UnityEngine;
using System;
using UnityEngine.SceneManagement;

namespace Mosaic{
    [CreateAssetMenu] public class GameManager : ScriptableObject{
        static public GameManager Current {get; private set;}

        [
            RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)
        ]
        static void Initialize(){
            Current = Resources.Load<GameManager>("GameManager");

            var gameControllerPrefab = Resources.Load<GameController>("GameController");

            gameController = Instantiate(gameControllerPrefab);

            DontDestroyOnLoad(gameController);

            gameController.name = gameControllerPrefab.name;
        }

        static GameController gameController;

        [Serializable] struct Sounds{
            public AudioClip click;
        }
        [Space, SerializeField] Sounds sounds;
        
        public void PlayClickSound() => gameController.components.audioSource.PlayOneShot(sounds.click);
        public void PlaySound(AudioClip audioClip) => gameController.components.audioSource.PlayOneShot(audioClip);

        public void Quit() => Application.Quit();
        public void LoadScene(string name){
            SceneManager.LoadScene(name);
        }
    }
}