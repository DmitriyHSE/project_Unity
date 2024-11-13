using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level2 : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other) 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("Last_level", SceneManager.GetActiveScene().buildIndex + 1);
    }
}
