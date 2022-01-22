using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFruits : MonoBehaviour
{

    public GameObject berry1;
    public GameObject berry2;
    public GameObject berry3;
    public GameObject berry4;
    public PlayerScript playerScript;
    public GameObject eatBerriesText;

    public bool isPlayerOnBerryRange;
    public int maxBerries = 4;
    public int berriesOnBush = 4;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RespawnBerryTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerOnBerryRange == true && Input.GetKeyDown(KeyCode.E) && berriesOnBush > 0)
        {
           
            playerScript.hp += 25;
            berriesOnBush -= 1;
            if(berry1.active == true)
            {
                berry1.SetActive(false);
            }
            else if(berry2.active == true)
            {
                berry2.SetActive(false);
            }else if (berry3.active == true)
            {
                berry3.SetActive(false);
            }
            else if (berry4.active == true)
            {
                berry4.SetActive(false);
            }
            
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        isPlayerOnBerryRange = true;
        eatBerriesText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        eatBerriesText.SetActive(false);
        isPlayerOnBerryRange = false;
    }

    private void RespawnBerry()
    {
        if (berry1.active == false)
        {
            berry1.SetActive(true);
            berriesOnBush += 1;
        }
        else if (berry2.active == false)
        {
            berry2.SetActive(true);
            berriesOnBush += 1;
        }
        else if (berry3.active == false)
        {
            berry3.SetActive(true);
            berriesOnBush += 1;
        }
        else if (berry4.active == false)
        {
            berry4.SetActive(true);
            berriesOnBush += 1;
        }

    }
    IEnumerator RespawnBerryTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            if (berriesOnBush < maxBerries)
            {
                
                RespawnBerry();
            }
        }
    }
}
