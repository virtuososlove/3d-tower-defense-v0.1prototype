using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defenderbarrackspawner : MonoBehaviour
{
    [SerializeField] GameObject barrackprefab;
    [SerializeField] GameObject currentbarrack;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(currentbarrack);
        }
        HandleNewObjectHotkey();
        if (currentbarrack != null)
        {
            MoveCurrentObjectToMouse(currentbarrack);
            releaseifclicked();
            rotateturret(currentbarrack);
        }
    }
    public void HandleNewObjectHotkey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(currentbarrack != null)
            {
                currentbarrack = null;
            }
            else
            {
                currentbarrack = Instantiate(barrackprefab);
            }
        }
    }
    private void MoveCurrentObjectToMouse(GameObject currentobject)
    {
        Ray mouseray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(mouseray,out hit))
        {
            currentobject.transform.position = hit.point;
        }
    }
    private void releaseifclicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentbarrack.transform.DetachChildren();
            currentbarrack.GetComponent<defenderspawner>().canuse = true;
            currentbarrack = null;
        }
    }
    private void rotateturret(GameObject currentobject)
    {
        if (Input.GetKey(KeyCode.F))
        {
            currentobject.transform.Rotate(Vector3.forward, 100f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.G))
        {
            currentobject.transform.Rotate(Vector3.forward, -100f * Time.deltaTime);
        }
    }
}
