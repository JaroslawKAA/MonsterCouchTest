using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SettingsMenuActions : MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
                OnBack();
        }

        public void OnBack()
        {
            Debug.Log("On Back");
            SceneManager.LoadScene("MainMenu");
        }
    }
}
