using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverChangeScene : MonoBehaviour
{
    public string NameScene;

    public void LoadScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("scene"));
    }
}
