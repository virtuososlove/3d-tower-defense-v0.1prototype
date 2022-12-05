using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretupgrader : MonoBehaviour
{
    public GameObject turretrotator;
    public GameObject turretprefab;
    public GameObject turret2prefab;
    public GameObject turret3prefab;
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Ray mouseray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(mouseray, out hit);
        if (Physics.Raycast(mouseray, out hit))
        {

            if (hit.transform.gameObject.CompareTag("level1"))
            {
                upgraderr(turretprefab, hit.transform.gameObject.transform.position);
            }
            if (hit.transform.gameObject.CompareTag("level2"))
            {
                upgraderr(turret2prefab, hit.transform.gameObject.transform.position);
            }
            if (hit.transform.gameObject.CompareTag("level3"))
            {
                upgraderr(turret3prefab, hit.transform.gameObject.transform.position);
            }
        }
    }
    public void upgraderr(GameObject turretprefab,Vector3 turretposition)
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            turretposition += new Vector3(0,45,0);
            GameObject turret = Instantiate(turretprefab, turretposition, Quaternion.identity);
            turret.GetComponent<mainturret>().candestroy = true;
            turret = null;
        }
    }
}
