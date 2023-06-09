using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public short sceneIndex; // Index of the scene to load for the 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneIndex);
//Agregar codigo de cambio de scene mandar al bd
        }
    }

    public void cambiarScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }

}
