using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    [SerializeField]
    private GameObject eyeBall;
    private float eyeIntervalTime = 4.0f;

    void Start()
    {
        StartCoroutine(spawnEnemy(eyeIntervalTime,eyeBall));
    }

    private IEnumerator spawnEnemy(float intervalo,GameObject enemy)
    {
        yield return new WaitForSeconds(intervalo);
        GameObject enemyObject = Instantiate(enemy,new Vector3(Random.Range(-21.0f,21f),Random.Range(8f,16f),0),Quaternion.identity);
    }


}
