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

    //public float hp;

    public PlayerScript playerScript;

    /*private void Start()
    {
        hp = playerScript.hp;
    }*/




    private void Update()
    {
        if (playerXP >= xpRequired)
        {
            LevelUp();
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
