using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoggedInChangeScene : MonoBehaviour
{
    public string NameScene;

    public void LoadSceneWW()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("id_nivel"));
    }
}
