using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CollectableCubes : MonoBehaviour
{
    bool isCollected;
    int index;
    AudioSource audioSource;

    public Collector collector;
    public ParticleSystem particle;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            audioSource.Play();
            Instantiate(particle, transform.position, Quaternion.identity);
            particle.Play();
            isCollected = false;
            transform.parent = null;
            transform.localPosition = new Vector3(transform.position.x + 0.3f, 1, transform.position.z);
            collector.reduceHeight();
            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            particle.Stop();
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
