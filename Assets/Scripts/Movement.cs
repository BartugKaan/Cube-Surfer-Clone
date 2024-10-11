using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float HorizontalSpeed;
    [SerializeField] private float VerticalSpeed;
    [SerializeField] private Collector collector;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (collector.isDead)
        {
            return;
        }
        float horizontal = Input.GetAxis("Horizontal") * HorizontalSpeed * Time.deltaTime;

        if (transform.position.z >= -4.6 && transform.position.z <= 4.6)
        {
            transform.Translate(horizontal, 0, VerticalSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -4.5f, 4.5f));
        }

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected");
        if (other.gameObject.tag == "Obstacle")
        {
            Debug.Log("Game Over");
        }
    }

}
