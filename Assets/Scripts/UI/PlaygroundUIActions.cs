using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class PlaygroundUIActions : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) 
                SceneManager.LoadScene("MainMenu");
        }
    }
}
