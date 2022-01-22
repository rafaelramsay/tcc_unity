using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBatteries : MonoBehaviour
{

    public PlayerScript playerScript;
        
    private bool isPlayerOnBatteryStorageRange = false;

    public GameObject battery1;
    public GameObject battery2;
    public GameObject battery3;

    public GameObject placeBatteriesText;

    public int batteriesPlaced = 0;

    private void OnTriggerEnter(Collider other)
    {
        isPlayerOnBatteryStorageRange = true;
        placeBatteriesText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerOnBatteryStorageRange = false;
        placeBatteriesText.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (isPlayerOnBatteryStorageRange == true && Input.GetKeyDown(KeyCode.E) && batteriesPlaced < 3 && playerScript.batteries > 0)
        {
            if(batteriesPlaced == 0)
            {
                batteriesPlaced += 1;
                battery1.SetActive(true);
                playerScript.batteries -= 1;
            }else if (batteriesPlaced == 1)
            {
                batteriesPlaced += 1;
                battery2.SetActive(true);
                playerScript.batteries -= 1;
            }
            else if (batteriesPlaced == 2)
            {
                batteriesPlaced += 1;
                battery3.SetActive(true);
                playerScript.batteries -= 1;

            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


}
