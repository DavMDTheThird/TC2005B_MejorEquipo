using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public short sceneIndex; // Index of the scene to load for the 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Scene_Changer"))
        {
            Player_stats playerBSC = collision.collider.gameObject.GetComponent<Player_stats>();
            playerBSC.SaveToJson();

            SceneManager.LoadScene(sceneIndex);
        }
    }
}
