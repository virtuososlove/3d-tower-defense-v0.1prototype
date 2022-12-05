using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityscale : MonoBehaviour
{
    public float scale;
    public float scalewithtime;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        scale += Time.deltaTime * scalewithtime;
        rb.AddForce(Physics.gravity * scale * Time.fixedDeltaTime, ForceMode.Acceleration);
    }
}
