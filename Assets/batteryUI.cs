using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class batteryUI : MonoBehaviour
{
 

    public PlaceBatteries placeBatteries;

    public GameObject batteryUI1;
    public GameObject batteryUI2;
    public GameObject batteryUI3;
    public GameObject portalUI;
    public GameObject turnOnPortalText;
    public GameObject turningOnPortalText;
    public GameObject portalBackground;
    public GameObject computerUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (placeBatteries.batteriesPlaced == 1)
        {
            batteryUI1.GetComponent<Image>().color = new Color32(49, 214, 11, 255);
        }
        else if (placeBatteries.batteriesPlaced == 2)
        {
            batteryUI1.GetComponent<Image>().color = new Color32(49, 214, 11, 255);
            batteryUI2.GetComponent<Image>().color = new Color32(49, 214, 11, 255);
        }
        else if (placeBatteries.batteriesPlaced == 3)
        {
            batteryUI1.GetComponent<Image>().color = new Color32(49, 214, 11, 255);
            batteryUI2.GetComponent<Image>().color = new Color32(49, 214, 11, 255);
            batteryUI3.GetComponent<Image>().color = new Color32(49, 214, 11, 255);
            portalUI.GetComponent<Image>().color = new Color32(49, 214, 11, 255);
            turnOnPortalText.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.T) && placeBatteries.batteriesPlaced == 3 && computerUI.active == true)
        {
            turningOnPortalText.SetActive(true);
            portalBackground.SetActive(true);
        }
    }
}
