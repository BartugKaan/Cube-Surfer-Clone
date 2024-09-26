using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float HorizontalSpeed;
    [SerializeField] private float VerticalSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * HorizontalSpeed * Time.deltaTime;

        this.transform.Translate(horizontal, 0, VerticalSpeed * Time.deltaTime);

    }
}
