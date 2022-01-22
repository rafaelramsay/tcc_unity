using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOnPortal : MonoBehaviour
{

    public GameObject portalBackground;
    public PlaceBatteries placeBatteries;
    public GameObject turningOnPortalText;
    public GameObject computerUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && placeBatteries.batteriesPlaced == 3 && computerUI.active == true)
        {
            turningOnPortalText.SetActive(true);
            portalBackground.SetActive(true);
        }
    }
}
