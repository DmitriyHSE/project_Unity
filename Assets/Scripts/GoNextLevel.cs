using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoNextLevel : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            if (SceneManager.GetActiveScene().buildIndex + 1 != 6)
                PlayerPrefs.SetInt("Last_level", SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}