using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diglet : MonoBehaviour
{
    public Animation anim;
    public Transform player;
    public bool isPlayerOnRange;
    public PlayerScript playerScript;
    public bool isTamed;
    public GameObject hungryIcon;
    public GameObject tamedIcon;
    public int speed;
    public GameObject digletImage;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        if(isPlayerOnRange == true && playerScript.berries > 0 && Input.GetKeyDown(KeyCode.F))
        {
            playerScript.berries -= 1;
            isTamed = true;
            hungryIcon.SetActive(false);
            tamedIcon.SetActive(true);
            anim.Play("DigletAnim");
            digletImage.SetActive(true);
        }
        if(!anim.IsPlaying("DigletAnim"))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            transform.LookAt(player);
        }
            
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnRange = false;
        }
    }
}
