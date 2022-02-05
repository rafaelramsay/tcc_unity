using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Animator anim;
	public float velGiro;
	
	private CharacterController controller;
	public float speed;
	private Vector3 moveDirection;
	public float gravity;
	
	public int hp;

	public int maxHP = 100;

	public HealthBarScript healthBar;

	public Transform spawnPos;

	public int batteries;

	
    // Start is called before the first frame update
    void Start()
    {
		hp = maxHP;
		healthBar.SetMaxHealth(maxHP);
		anim = GetComponent<Animator>(); 
		controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() 
	{

		anim.SetFloat("Speed", Input.GetAxis("Vertical"));
		transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * velGiro * Time.deltaTime, 0));
		Move();
		
		if(Input.GetButtonDown("Jump")){
			anim.SetBool("Jumping", true);
			Invoke("StopJump", 0.1f);
		}
		if(Input.GetButtonDown("AttackPunch")){
			anim.SetBool("Attacking", true);
		}else {
			anim.SetBool("Attacking", false);
		}

		if(hp <= 0)
        {
            Application.LoadLevel(0);
		}
        
        if(hp > maxHP)
        {
            hp = maxHP;
        }
	}
		
	
	void StopJump(){
		anim.SetBool("Jumping", false);
	}

	
	void Move(){
		if(controller.isGrounded){
			if (Input.GetKey(KeyCode.W)){
				moveDirection = Vector3.forward * speed;
			}
			if(Input.GetKeyUp(KeyCode.W)){
				moveDirection = Vector3.zero;
			}
		}
	
		
		moveDirection.y -= gravity * Time.deltaTime;
		
		moveDirection = transform.TransformDirection(moveDirection);
		
		controller.Move(moveDirection * Time.deltaTime);
	}
	
	
	public void RemoveHP(int damage){
		hp -= damage;
		healthBar.SetHealth(hp);
	}

	void OnTriggerEnter(Collider colisor)
	{
		if (colisor.gameObject.tag == "spider1")
		{
			RemoveHP(10);
		}
		else if (colisor.gameObject.tag == "spider2")
		{
			RemoveHP(25);
		}else if (colisor.gameObject.tag == "spiderBoss")
		{
			RemoveHP(50);
		}
		

	}
}