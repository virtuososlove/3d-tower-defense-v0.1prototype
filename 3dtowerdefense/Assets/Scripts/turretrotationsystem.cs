using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretrotationsystem : MonoBehaviour
{
    [SerializeField] GameObject turretprefab;
    [SerializeField] GameObject currentturret;
    [SerializeField] Animator canvasanims;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Destroy(currentturret);
        }
        HandleNewObjectHotkey();
        if (currentturret != null)
        {
            MoveCurrentObjectToMouse();
            rotateturret();
            releaseifclicked();
        }
    }
    public void HandleNewObjectHotkey()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(currentturret != null)
            {
                Destroy(currentturret);
            }
            else
            {
                currentturret = Instantiate(turretprefab);
            }
        }
            
        
       
    }
    private void MoveCurrentObjectToMouse()
    {
        Ray mouseray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(mouseray, out hit);
        if (Physics.Raycast(mouseray, out hit))
        {
            currentturret.transform.position = hit.point;
        }

    }
    private void releaseifclicked()
    {
        Collider[] hits = Physics.OverlapSphere(currentturret.transform.position, 5f);
        Collider[] patrolhit = Physics.OverlapSphere(currentturret.transform.position, 8f);
        for (int j = 0; j < hits.Length; j++)
        {
            if (hits[j].transform.gameObject.GetComponent<mainturret>() != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    canvasanims.SetTrigger("errortrig");
                }
                return;
            }
        }
        for (int j = 0; j < hits.Length; j++)
        {
            if (patrolhit[j].transform.gameObject.GetComponent<patrolcontroller>() != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    canvasanims.SetTrigger("errortrig");
                }
                return;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            currentturret.transform.GetChild(0).transform.GetChild(1).GetComponent<turretcontroller>().canuse = true;
            currentturret.GetComponent<CapsuleCollider>().enabled = true;
            currentturret = null;
        }
    }
    private void rotateturret()
    {
        if (Input.GetKey(KeyCode.F))
        {
            currentturret.transform.Rotate(Vector3.up, 100f*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.G))
        {
            currentturret.transform.Rotate(Vector3.up, -100f*Time.deltaTime);
        }
    }
}
