using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUI : MonoBehaviour
{
    public GameManager gameManager;
    public Text text;


    public string damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = gameManager.playerDamage.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        damage = gameManager.playerDamage.ToString();
        text.text = damage;
    }
}
