using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject gameObject;
    public Vector3 offset;
    public Collector collector;
    public Movement movement;

    void Start()
    {
    }

    void LateUpdate()
    {
        if (collector.isDead)
        {
            return;
        }

        transform.position = Vector3.Lerp(transform.position, gameObject.transform.position + offset, Time.deltaTime);
    }
}
