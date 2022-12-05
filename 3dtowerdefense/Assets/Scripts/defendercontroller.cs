using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class defendercontroller : MonoBehaviour
{
    NavMeshAgent defendernavmesh;
    Animator defenderanimator;
    public float hp = 20;
    public float targetarea;
    enemycontroller enemycontroller;
    Vector3 velocity;
    public Vector3 spawnposition;
    public bool cango = true;
    void Start()
    {
        defendernavmesh = this.GetComponent<NavMeshAgent>();
        defenderanimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        gotoposition();
        animatorupdater();
        if (cango != true)
        {
            killdefender();
            controller();
            newattack();
            
        }
    }
    public void controller()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, targetarea);
        if (enemycontroller != null)
        {
            return;
        }
        float closest = 110;
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].gameObject.tag == "enemy")
            {
                if (Vector3.Distance(transform.position, hits[i].transform.position) < closest)
                {
                    closest = Vector3.Distance(transform.position, hits[i].transform.position);
                    enemycontroller = hits[i].GetComponent<enemycontroller>();
                }
            }
        }
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].gameObject.tag == "enemy")
            {
                return;
            }
        }
        backtoposition();
    }
    public void hitenemy()
    {
        enemycontroller.hp -= 5;
        
    }
    void killdefender()
    {
        if (hp <= 0)
        {
            defenderanimator.SetTrigger("cantattack");
            defenderanimator.ResetTrigger("canattack");
            Invoke("destroying", 0.1f);
            enabled = false;
            return;
        }
    }
    void destroying()
    {
        Destroy(gameObject);
    }
    public void newattack()
    {
        if (enemycontroller == null)
        {
            return;
        }
        defendernavmesh.destination = enemycontroller.transform.position;
        defendernavmesh.isStopped = false;
        if (Vector3.Distance(transform.position, enemycontroller.transform.position) < 2.5 && !defenderanimator.IsInTransition(0))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(enemycontroller.gameObject.transform.position - transform.position), 15f * Time.deltaTime);

            defendernavmesh.destination = transform.position;
            defenderanimator.SetTrigger("canattack");
            defenderanimator.ResetTrigger("cantattack");
        }
        if (enemycontroller.hp <= 0)
        {
            defenderanimator.ResetTrigger("canattack");
            defendernavmesh.isStopped = false;
            defenderanimator.SetTrigger("cantattack");
            enemycontroller = null;
        }
    }
    void animatorupdater()
    {
        velocity = defendernavmesh.velocity;
        Vector3 localvelocity = transform.InverseTransformDirection(velocity);
        float speed = localvelocity.z;
        defenderanimator.SetFloat("velocity", speed);
    }
    void backtoposition()
    {
        if(Vector3.Distance(transform.position, spawnposition) < 3f)
        {
            defendernavmesh.isStopped = true;
            return;
        }
        if (Vector3.Distance(transform.position, spawnposition) > 1f)
        {
            defendernavmesh.destination = spawnposition;
            defendernavmesh.isStopped = false;
        }
        defenderanimator.SetTrigger("cantattack");
        defenderanimator.ResetTrigger("canattack");
    }
    void gotoposition()
    {
        if (Vector3.Distance(transform.position, spawnposition) < 1f)
        {
            cango = false;
            defendernavmesh.isStopped = true;
        }
        if (Vector3.Distance(transform.position, spawnposition) > 1f && cango == true)
        {
            defendernavmesh.destination = spawnposition;
            defenderanimator.SetTrigger("cantattack");
            defenderanimator.ResetTrigger("canattack");
            defendernavmesh.isStopped = false;
        }
    }
}
