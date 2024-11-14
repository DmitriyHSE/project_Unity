using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("Last_level", SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Continue()
    {
        int lastLevel = PlayerPrefs.GetInt("Last_level");
        SceneManager.LoadScene(lastLevel);
    }
}
