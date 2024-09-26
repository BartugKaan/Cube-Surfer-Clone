using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject gameObject;
    public Vector3 offset;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, gameObject.transform.position + offset, Time.deltaTime);
    }
}
