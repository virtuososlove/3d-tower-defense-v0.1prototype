using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defenderspawner : MonoBehaviour
{
    public float delaytime2 = 5f;
    float delaytime = 5f;
    float delaytime3 = 5f;
    public GameObject defenderprefab;
    public GameObject spawnposition;
    GameObject defender1;
    GameObject defender2;
    GameObject defender3;
    public bool canuse = false;
    public Transform defendtransform;
    public Transform defendtransform2;
    public Transform defendtransform3;
    void Update()
    {
        if(canuse == true)
        {
            spawnerdefender();
        }
        
    }
    void spawnerdefender()
    {
        if (defender1 == null)
        {
            delaytime2 -= Time.deltaTime;
            if (delaytime2 <= 0)
            {
                transform.InverseTransformVector(transform.position);
                defender1 = Instantiate(defenderprefab, spawnposition.transform.position, Quaternion.identity);
                defender1.GetComponent<defendercontroller>().spawnposition = defendtransform.localPosition;

                delaytime2 = 15f;
            }
        }
        else if (defender2 == null)
        {
            delaytime -= Time.deltaTime;
            if (delaytime <= 0)
            {
                defender2 = Instantiate(defenderprefab, spawnposition.transform.position, Quaternion.identity);
                defender2.GetComponent<defendercontroller>().spawnposition = defendtransform2.position;

                delaytime = 15f;
            }
        }
        else    if (defender3 == null)
        {
            delaytime3 -= Time.deltaTime;
            if (delaytime3 <= 0)
            {
                defender3 = Instantiate(defenderprefab, spawnposition.transform.position, Quaternion.identity);
                defender3.GetComponent<defendercontroller>().spawnposition = defendtransform3.position;
                delaytime3 = 15f;
            }
        }
    }
}
