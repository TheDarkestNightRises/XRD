using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public InputAction startGameAction;
    public InputAction quitGameAction;

    private void OnEnable()
    {
        startGameAction.Enable();
        quitGameAction.Enable();
    }

    private void OnDisable()
    {
        startGameAction.Disable();
        quitGameAction.Disable();
    }

    private void Update()
    {
        if (startGameAction.triggered)
        {
            StartGame();
        }

        if (quitGameAction.triggered)
        {
            QuitGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SciencLaboratory3");
    }

    public void QuitGame()
    {
        Debug.Log("Game is quitting...");
        Application.Quit();
    }
}
