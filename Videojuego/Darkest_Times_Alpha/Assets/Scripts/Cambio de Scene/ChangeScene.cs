using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public short sceneIndex; // Index of the scene to load for the collider
    json_ReadWrite json;


    private void Start()
    {
        json = new json_ReadWrite();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.CompareTag("Scene_Changer"))
        {
            Debug.Log("Hola");
            json.SaveToJson();
            Debug.Log("Adios");
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
