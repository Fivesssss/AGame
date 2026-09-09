using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu() 
    {
        SceneManager.LoadScene("Main Menu");
    }
}
