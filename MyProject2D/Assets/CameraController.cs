using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;

    public float speed;

    private Vector3 targetPosition;
    
    private void Update()
    {
        targetPosition = target.transform.position;
        targetPosition.y = transform.position.y;
        targetPosition.z = -10;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed);
    }
}
