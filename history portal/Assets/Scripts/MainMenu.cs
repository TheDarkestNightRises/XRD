using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartScene()
    {
        SceneManager.LoadScene(1); 
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
