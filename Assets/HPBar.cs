using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
	public RectTransform HPbar;
	public PlayerScript player;
	private float MaxHP;
	private float MaxBarWidth;
	
    // Start is called before the first frame update
    void Start()
    {
        MaxHP = player.hp;
		MaxBarWidth = HPbar.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        HPbar.sizeDelta = new Vector2(CalculaHP(), HPbar.rect.height);
    }
	
	public float CalculaHP(){
		return (player.hp * MaxBarWidth) / MaxHP;
	}
}
