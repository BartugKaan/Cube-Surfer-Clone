using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CollectableCubes : MonoBehaviour
{
    bool isCollected;
    int index;

    public Collector collector;

    void Start()
    {

    }

    void Update()
    {
        if (isCollected)
        {
            if (transform.parent != null)
            {
                transform.localPosition = new Vector3(0, -index, 0);
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            collector.reduceHeight();
            transform.parent = null;
            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public bool isCollectedCube()
    {
        return isCollected;
    }

    public void setCollected()
    {
        isCollected = true;
    }

    public void setIndex(int index)
    {
        this.index = index;
    }
}
