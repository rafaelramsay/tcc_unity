using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayGame();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

}
