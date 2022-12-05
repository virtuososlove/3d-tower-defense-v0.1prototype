using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uicontroller : MonoBehaviour
{

    public Text cointext;
    public enemycontroller enemycontroller;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cointext.text = enemycontroller.coin.ToString();
    }
}
