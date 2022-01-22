using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterComputer : MonoBehaviour
{
    private bool isPlayerOnComputerRange = false;

    public GameObject computerUI;

    public GameObject turnOnComputerText;

    private void OnTriggerEnter(Collider other)
    {
        isPlayerOnComputerRange = true;
        turnOnComputerText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerOnComputerRange = false;
        turnOnComputerText.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerOnComputerRange == true && Input.GetKeyDown(KeyCode.E) && !computerUI.active == true)
        {
            computerUI.SetActive(true);
            Cursor.visible = true;
            turnOnComputerText.SetActive(false);
        }else if(isPlayerOnComputerRange == true && computerUI.active == false && turnOnComputerText.active == false)
        {
            turnOnComputerText.SetActive(true);
        }
    }
}
