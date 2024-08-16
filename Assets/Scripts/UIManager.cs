using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject restartPanel; // Reference to the Restart Panel

    void Start()
    {
        // Ensure the panel is hidden at the start
        restartPanel.SetActive(false);
    }

    public void ShowRestartPanel()
    {
        restartPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void HideRestartPanel()
    {
        restartPanel.SetActive(false);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu"); 
    }
}
