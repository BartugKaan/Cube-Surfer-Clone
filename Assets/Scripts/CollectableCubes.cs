using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CollectableCubes : MonoBehaviour
{
    bool isCollected;
    int index;

    public Collector collector;
    public ParticleSystem particle;
    private Animation animation;

    void Start()
    {
        animation = GetComponent<Animation>();
        animation.Play();
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
            animation.Stop();
            Instantiate(particle, transform.position, Quaternion.identity);
            particle.Play();
            isCollected = false;
            transform.parent = null;
            transform.localPosition = new Vector3(transform.position.x, 1, transform.position.z);
            collector.reduceHeight();
            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            DestroyImmediate(particle);
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
