using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenuActions : MonoBehaviour
    {
        public void OnPlay()
        {
            Debug.Log("On Play");
            SceneManager.LoadScene("Playground");
        }

        public void OnSettings()
        {
            Debug.Log("On Settings");
            SceneManager.LoadScene("SettingsMenu");
        }

        public void OnExit()
        {
            Debug.Log("On Exit");

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}