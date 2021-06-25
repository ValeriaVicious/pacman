using UnityEngine;
using UnityEngine.SceneManagement;


namespace Pacman
{
    internal sealed class MainMenu : MonoBehaviour
    {
        #region Methods

        public void StartButton()
        {
            SceneManager.LoadScene(Constants.GameScene);
        }

        public void AboutButton()
        {
            SceneManager.LoadScene(Constants.AboutScene);
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene(Constants.MainMenu);
        }

        public void SettingsButton()
        {
            SceneManager.LoadScene(Constants.SettingsScene);
        }

        public void ExitButton()
        {
            Application.Quit();
        }

        #endregion
    }
}