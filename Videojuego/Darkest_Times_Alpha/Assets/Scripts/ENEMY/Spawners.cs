using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    private float eyeIntervalTime = 10.0f;

    void Start()
    {
        InvokeRepeating("spawnEnemy",eyeIntervalTime,eyeIntervalTime);
    }

    private void spawnEnemy()
    {
        GameObject enemyObject = Instantiate(enemy,new Vector3(Random.Range(-21.0f,21f),Random.Range(8f,16f),0),Quaternion.identity);
    }


}
