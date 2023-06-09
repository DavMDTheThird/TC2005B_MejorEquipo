/*
Script to control the motion of an agent that uses
NavMesh in 2D

Gilberto Echeverria
2023-04-10
*/

using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]

public class MovementIA : MonoBehaviour
{
    [SerializeField] Transform target;
    private bool isFound;

    NavMeshAgent nvAgent;

    // Start is called before the first frame update
    void Start()
    {

        nvAgent = GetComponent<NavMeshAgent>();
        nvAgent.updateRotation = false;
        nvAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFound)
        {
            target = GameObject.FindWithTag("Player").transform;
            isFound = true;
        }
        nvAgent.destination = target.position;
    }
}
