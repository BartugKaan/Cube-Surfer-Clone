using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCubes : MonoBehaviour
{
    bool isCollected;
    int index;

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
