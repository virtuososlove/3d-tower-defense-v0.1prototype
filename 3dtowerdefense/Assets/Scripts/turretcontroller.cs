using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretcontroller : MonoBehaviour
{
    [SerializeField] float turretrange;
    public enemycontroller enemycontroller;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletplace;
    public float timetofire;
    [SerializeField] float reloadtime;
    [SerializeField] GameObject bulletplace2;
    [SerializeField] GameObject bulletplace3;
    [SerializeField] GameObject bulletplace4;
    Transform startposition;
    public bool canuse = false;

    private void Start()
    {
        timetofire = reloadtime;
        startposition = transform;

    }
    void Update()
    {
        if(canuse == true)
        {
            targetingenemy();
            attackingenemy();

        }
    }
    private void targetingenemy()
    {
        Collider[] enemycolliders = Physics.OverlapSphere(startposition.position, turretrange);
        if (enemycontroller == null)
        {
            for (int i = 0; i < enemycolliders.Length; i++)
            {
                if (enemycolliders[i].gameObject.tag == "enemy")
                {
                    enemycontroller = enemycolliders[i].GetComponent<enemycontroller>();
                    return;
                }
            }
        }
    }
    private void attackingenemy()
    {
        if (enemycontroller == null) return;
        if (Vector3.Distance(startposition.position, enemycontroller.transform.position) >= turretrange)
        {
            enemycontroller = null;
        }
        if(enemycontroller != null)
        { 

            Vector3 enemyposition = enemycontroller.transform.position + new Vector3(0, 2f,0);
            transform.LookAt(enemycontroller.transform.GetChild(0).transform);
            timetofire -= Time.deltaTime;
            if (timetofire <= 0.1)
            {
                StartCoroutine(delaytofire());
                timetofire = reloadtime;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        UnityEditor.Handles.color = Color.green;
        UnityEditor.Handles.DrawWireDisc(transform.position - new Vector3(0,0.65f,0), Vector3.up, turretrange);
        if (enemycontroller == null) return;
        Gizmos.DrawLine(bulletplace.transform.position, enemycontroller.transform.GetChild(0).transform.position);
        if(gameObject.tag == "level2")
        {
            Gizmos.DrawLine(bulletplace2.transform.position, enemycontroller.transform.GetChild(0).transform.position);
        }
        if (gameObject.tag == "level3")
        {
            Gizmos.DrawLine(bulletplace2.transform.position, enemycontroller.transform.GetChild(0).transform.position);
            Gizmos.DrawLine(bulletplace3.transform.position, enemycontroller.transform.GetChild(0).transform.position);
        }
        if (gameObject.tag == "level4")
        {
            Gizmos.DrawLine(bulletplace2.transform.position, enemycontroller.transform.GetChild(0).transform.position);
            Gizmos.DrawLine(bulletplace3.transform.position, enemycontroller.transform.GetChild(0).transform.position);
            Gizmos.DrawLine(bulletplace4.transform.position, enemycontroller.transform.GetChild(0).transform.position);
    
        }
    }
    void firebullet(GameObject bulletplace)
    {
        GameObject bullet1 = Instantiate(bullet, bulletplace.transform.position, Quaternion.identity);
        bullet1.GetComponent<bulletcontroller>().enemycontroller = enemycontroller;
    }
    private IEnumerator delaytofire()
    {
        firebullet(bulletplace);
        if (gameObject.tag == "level1") yield break;
        yield return new WaitForSeconds(0.1f);
        firebullet(bulletplace2);
        if (gameObject.tag == "level2") yield break;
        yield return new WaitForSeconds(0.1f);
        firebullet(bulletplace3);
        if(gameObject.tag == "level3") yield break;
        yield return new WaitForSeconds(0.1f);
        firebullet(bulletplace4);
    }
}
 
