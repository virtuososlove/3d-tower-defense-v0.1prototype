using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroler : MonoBehaviour
{
    float xrotation = 0f;
    float yrotation = 0f;
    float xposition = 0f;
    float zposition = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xposition = Input.GetAxis("Horizontal") * Time.deltaTime * 15f;
        zposition = Input.GetAxis("Vertical") * Time.deltaTime * 15f;
        xrotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * 800f;
        yrotation +=  Input.GetAxis("Mouse X") * Time.deltaTime * 800f;
        xrotation = Mathf.Clamp(xrotation, -90, 90);
        transform.localRotation = Quaternion.Euler(xrotation, yrotation, 0);
        transform.Translate(xposition, 0, zposition);
    }
}
