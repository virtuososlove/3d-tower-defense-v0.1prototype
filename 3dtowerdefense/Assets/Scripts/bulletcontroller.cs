using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletcontroller : MonoBehaviour
{
    public enemycontroller enemycontroller;
    [SerializeField] float speed = 2;
    void Update()
    {
        if (enemycontroller == null) Destroy(gameObject);
        if (enemycontroller == null) return;
        transform.LookAt(enemycontroller.transform.GetChild(0).transform.position);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
