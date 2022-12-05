using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolcontroller : MonoBehaviour
{
    [SerializeField] float size;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, size);
    }
}
