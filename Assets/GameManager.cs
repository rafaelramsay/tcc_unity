using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int spiders1OnGame;

    public int spiders2OnGame;

    public int playerDamage = 10;

    public int playerLvL = 1;

    public int playerXP = 0;

    public int xpRequired = 100;

    public int maxHP = 100;

    public GameObject playerMenu;

    public GameObject things;

    public bool isMeatActive = false;

    public GameObject spiderImage;



    //public float hp;

    public PlayerScript playerScript;

    private void Start()
    {
        Cursor.visible = false;
    }




    void Update()
    {
        if (playerXP >= xpRequired)
        {
            LevelUp();
        }

        if (playerMenu.active == false && Input.GetButtonDown("OpenMenu"))
        {
            playerMenu.SetActive(true);
            things.SetActive(false);
        }else if(playerMenu.active == true && Input.GetButtonDown("OpenMenu"))
        {
            playerMenu.SetActive(false);
            things.SetActive(true);
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void LevelUp()
    {
        playerLvL += 1;
        maxHP += 5;
        playerScript.hp = maxHP;
        playerXP -= xpRequired;
        xpRequired += 25;
        playerDamage += 5;
    }

    
}
