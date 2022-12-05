using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemycontroller : MonoBehaviour
{
    public int sayi = 0;
    public float targetarea;
    defendercontroller defendercontroller;
    NavMeshAgent enemynavmesh;
    Animator enemyanimator;
    public float hp = 20;
    public bool candestroy = false;
    public static int coin = 200;
    bool canadd = true;
    void Start()
    {
        enemynavmesh = this.GetComponent<NavMeshAgent>();
        enemyanimator = this.GetComponent<Animator>();
    }
    void Update()
    {
        if(hp <= 0)
        {

            Invoke("destroyerr", 0.1f);
        }
        attack();
        newattack();
    }
    public void attack()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, targetarea);
        if(defendercontroller != null)
        {
            return;
        }
        float closest=110;
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].gameObject.tag == "Player")
            {
                if (Vector3.Distance(transform.position, hits[i].transform.position) < closest)
                {
                    closest = Vector3.Distance(transform.position, hits[i].transform.position);
                    defendercontroller = hits[i].gameObject.GetComponent<defendercontroller>();
                }
            }
        }
            for (int j = 0; j < hits.Length; j++)
            {
                if (hits[j].gameObject.tag == "Player")
                {
                    return;
                }
            }
            walkforward(); 
    }
    public void walkforward()
    {
        GameObject patrolpath = GameObject.Find("patrol");
        enemyanimator.ResetTrigger("canattack");
        enemynavmesh.isStopped = false;
        enemyanimator.SetTrigger("cantattack");
        enemynavmesh.destination = patrolpath.transform.GetChild(sayi).position;
        if(sayi == 18)
        {
            Destroy(gameObject);
        }
        if (Vector3.Distance(transform.position, patrolpath.transform.GetChild(sayi).position) < 1)
        {
            sayi += 1;
        }
    }
    public void enemyhitted()
    {
        defendercontroller.hp -= 5;
    }
    public void newattack()
    {
        if(defendercontroller == null)
        {
            return;
        }
        enemynavmesh.destination = defendercontroller.transform.position;
        if (Vector3.Distance(transform.position, defendercontroller.transform.position) < 2.5)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(defendercontroller.gameObject.transform.position - transform.position),15f*Time.deltaTime);
            enemynavmesh.isStopped = true;
            enemyanimator.SetTrigger("canattack");
            enemyanimator.ResetTrigger("cantattack");
        }
        if (defendercontroller.gameObject.GetComponent<defendercontroller>().hp <= 0)
        {
            enemyanimator.ResetTrigger("canattack");
            enemynavmesh.isStopped = false;
            enemyanimator.SetTrigger("cantattack");
            defendercontroller = null;
        }
    }
    void destroyerr()
    {
        if(canadd == true)
        {
            coin += 10;
            canadd = false;
        }

        Destroy(gameObject);
    }
}
