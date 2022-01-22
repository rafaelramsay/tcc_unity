using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBarScript : MonoBehaviour
{

    public HealthBarScript healthBar;
    public SpiderScript spiderScript;

    public int maxHP;
    public int hp;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = spiderScript.maxHP;
        healthBar.SetMaxHealth(maxHP); 
    }

    // Update is called once per frame
    void Update()
    {
        maxHP = spiderScript.maxHP;
        hp = spiderScript.hp;
        healthBar.SetHealth(hp);
    }
}
