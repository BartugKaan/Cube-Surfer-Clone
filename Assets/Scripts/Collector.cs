using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{
    public GameObject mainCube;
    public AudioSource collectionSound;
    public AudioSource hitSound;
    int collectedCubes = 0;
    public bool isDead = false;
    [SerializeField] private ParticleSystem particle;

    void Start()
    {
        mainCube = GameObject.Find("Main Cube");
    }

    // Update is called once per frame
    void Update()
    {
        mainCube.transform.position = new Vector3(transform.position.x, collectedCubes + 1, transform.position.z);
        transform.localPosition = new Vector3(0, -collectedCubes, 0);
    }

    public void reduceHeight()
    {
        collectedCubes--;
    }

    public void setDead()
    {
        isDead = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable" && other.GetComponent<CollectableCubes>().isCollectedCube() == false)
        {
            collectionSound.Play();
            Vector3 particlePos = new Vector3(other.transform.position.x + 1.2f, other.transform.position.y, other.transform.position.z);
            Instantiate(particle, particlePos, Quaternion.identity);
            particle.Play();
            collectedCubes += 1;
            other.gameObject.GetComponent<CollectableCubes>().setCollected();
            other.gameObject.GetComponent<CollectableCubes>().setIndex(collectedCubes);
            other.gameObject.transform.parent = mainCube.transform;
        }
        else if (collectedCubes == 0 && other.gameObject.tag == "Obstacle")
        {
            hitSound.Play();
            setDead();
            Debug.Log("Game Over");

        }
    }
}
