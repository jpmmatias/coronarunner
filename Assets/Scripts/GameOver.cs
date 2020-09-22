﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
  
    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }

}
