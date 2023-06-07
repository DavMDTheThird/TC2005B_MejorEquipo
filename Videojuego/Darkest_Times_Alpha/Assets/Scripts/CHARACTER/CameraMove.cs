using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public float yOffset = 1f;

    public Vector2 maxPosition;
    public Vector2 minPosition;

    private GameObject[] objectToFollowTAG;

    void Start()
    {
        objectToFollowTAG = GameObject.FindGameObjectsWithTag("Player");
        target = objectToFollowTAG[0].transform;
        if (target == null)
        {
            Debug.LogWarning("Target object not found with tag: " + "Player");
        }
        transform.position = new Vector3(target.position.x, target.position.y + yOffset, transform.position.z);
    }

    private void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y + yOffset, transform.position.z);

            targetPosition.x = Mathf.Clamp(target.position.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(target.position.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }
}
