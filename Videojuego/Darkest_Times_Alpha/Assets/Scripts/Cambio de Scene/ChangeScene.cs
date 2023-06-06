using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public short sceneIndex; // Index of the scene to load for the 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
//Agregar codigo de camio de scene mandar al bd
        }
    }
}
