using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playbutton : MonoBehaviour
{

    public int gameStartScreen;

    void StartGame()
    {
        SceneManager.LoadScene(gameStartScreen);
    }
}
