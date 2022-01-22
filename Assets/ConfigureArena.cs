using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigureArena : MonoBehaviour
{

    public GameObject bossBar1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        bossBar1.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        bossBar1.SetActive(false);
    }
}
