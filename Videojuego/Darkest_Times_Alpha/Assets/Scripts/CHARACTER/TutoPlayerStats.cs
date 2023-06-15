using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class Player_stats : MonoBehaviour
{
    Player_basic playerBSC = new Player_basic(10, 10, 0, 0, 50, 2, 5, 5, 1, 0);

    public List<GameObject> HeartContainer;


    void Start()
    {
        // PlayerPrefs.SetInt("id", 1);
        // PlayerPrefs.SetInt("id_personaje", 1);
        // PlayerPrefs.SetInt("personaje", 1);
        // PlayerPrefs.SetInt("id_inventario", 1);
        // PlayerPrefs.SetInt("id_checkpoint", 1);


        HeartContainer.Add(GameObject.Find("0Hearts"));
        HeartContainer.Add(GameObject.Find("1Hearts"));
        HeartContainer.Add(GameObject.Find("2Hearts"));
        HeartContainer.Add(GameObject.Find("3Hearts"));
        HeartContainer.Add(GameObject.Find("4Hearts"));
        HeartContainer.Add(GameObject.Find("5Hearts"));
        HeartContainer.Add(GameObject.Find("6Hearts"));
        HeartContainer.Add(GameObject.Find("7Hearts"));
        HeartContainer.Add(GameObject.Find("8Hearts"));
        HeartContainer.Add(GameObject.Find("9Hearts"));
        HeartContainer.Add(GameObject.Find("10Hearts"));
    }



    // Testing
    void Update()
    {
        if (playerBSC != null && playerBSC.HP == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    // Player interactions
    public void TakeDamage(short damage)
    {
        if (playerBSC.HP - damage <= 0)
        {
            playerBSC.HP = 0;
        }
        else
        {
            playerBSC.HP -= damage;
        }
        ShowHearts();
        //Debug.Log(transform.name + " took: " + damage + " damage. HP now: " + playerBSC.HP);
    }

    public void GetMoney(short money)
    {
        playerBSC.Money += money;
        Debug.Log(transform.name + " gain: " + money + " money. Total money now: " + playerBSC.Money);
    }

    public void ShowHearts()
    {
        //Debug.Log(playerBSC.HP);
        short i = 0;
        foreach (GameObject obj in HeartContainer)
        {
            obj.SetActive(false);

            if(playerBSC.HP == i)
            {
                obj.SetActive(true);
            }
            ++i;
        }

    }
}