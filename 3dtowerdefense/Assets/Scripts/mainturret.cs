using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainturret : MonoBehaviour
{
    public bool candestroy = false;
    void Update()
    {
        if(gameObject.tag != "level1")
        {
            if (transform.position.y <= 0.15)
            {
                if (transform.GetChild(0).transform.GetChild(0).GetComponent<turretcontroller>() != null)
                {
                    transform.GetChild(0).transform.GetChild(0).GetComponent<turretcontroller>().canuse = true;
                }
                if (transform.GetChild(0).transform.GetChild(1).GetComponent<turretcontroller>() != null)
                {
                    transform.GetChild(0).transform.GetChild(1).GetComponent<turretcontroller>().canuse = true;
                }
                transform.position = new Vector3(transform.position.x, 0.10f, transform.position.z);
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
        }
       
    }
    private void OnTriggerEnter(Collider collision)
    {
        if ((collision.gameObject.tag == "level1" || collision.gameObject.tag == "level2" || collision.gameObject.tag == "level3") && candestroy == true)
        {
            Destroy(collision.gameObject);
            candestroy = false;
        }
    }
}
