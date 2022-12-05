using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class range : MonoBehaviour
{
    [RequireComponent(typeof(Rigidbody))]
    public class GravityScale : MonoBehaviour
    {
        public float gravityScale = 1f; //The gravity scale
        public float gravityscale;
        Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            rb.AddForce(Physics.gravity * 1000* Time.fixedDeltaTime, ForceMode.Acceleration); //It has to be FixedUpdate, because it applies force to the rigidbody constantly.
        }
    }
}
