using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public PlayerScript playerScript;


    public void OnTriggerEnter(Collider other)
    {
        playerScript.batteries += 1;
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
