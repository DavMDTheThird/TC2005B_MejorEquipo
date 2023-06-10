using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesGame : MonoBehaviour
{
    public string NameScene;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(NameScene);
    }
}
