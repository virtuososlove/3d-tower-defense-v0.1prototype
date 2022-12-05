using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<enemycontroller>() != null)
        {
            other.GetComponent<enemycontroller>().hp -= 5;
            Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }
    }
}
