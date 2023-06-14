using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    private float eyeIntervalTime = 25.0f;

    void Start()
    {
        if(enemy.tag == "eyeBall"){
            InvokeRepeating("spawnEnemy",eyeIntervalTime,eyeIntervalTime);
        }
    }

    private void spawnEnemy()
    {
        GameObject enemyObject = Instantiate(enemy,gameObject.transform.position,Quaternion.identity);
    }


}
