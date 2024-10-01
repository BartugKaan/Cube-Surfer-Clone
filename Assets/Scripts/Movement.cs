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

        transform.Translate(horizontal, 0, VerticalSpeed * Time.deltaTime);
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
