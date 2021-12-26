using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour{
	
	public float maxRange = 30f;
	private float currentRange;
	public Transform player;
	Animation anim;
	public GameObject battery;
	
	public float spiderSpeed = 4f;
	
	//Attack
	private BoxCollider areaAttack;
	private bool attacking =  false;
	public float attackRange = 8f;

	//Damage
	public bool isDead = false;


	//HP
	public float HP = 100f;

	private bool isOnPlayerAttackRange = false;

	private bool attackCoolDown = false;


	// Start is called before the first frame update
	void Start()
    {
        anim = GetComponent<Animation>();
		areaAttack = GetComponent<BoxCollider>();
		
		player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnPlayerAttackRange == true && HP > 0 && Input.GetButtonDown("AttackPunch") && attackCoolDown == false)
        {
			Damage();
        }else if(HP <= 0)
        {
			Die();
        }

        if(attackCoolDown == true)
        {
            Invoke(nameof(AttackDelay), 3.833f);
        }
		

		attacking = anim.IsPlaying("Attack");
		areaAttack.enabled = anim.IsPlaying("Attack");
		
	   currentRange = Vector3.Distance(transform.position, player.transform.position);
	   
	   
	   if(currentRange <= attackRange){
		   Attack();
	   }
	   
		else if(currentRange <= maxRange && !anim.IsPlaying("Death")){
		  transform.LookAt (player);
		  transform.position += transform.forward * spiderSpeed * Time.deltaTime;
		  anim.Play("Walk");
		}else if(!anim.IsPlaying("Death")){
			anim.Play("Idle");
		}
	}	
	
	void Attack(){
		if(!attacking && !anim.IsPlaying("Death")){
			attacking = true;
			anim.Play("Attack");
		}
	}

	void Damage()
    {
		HP -= GameManager.Instance.playerDamage;
		attackCoolDown = true;
    }

	void Die()
    {
		if (isDead == false)
		{
			anim.Play("Death");
			isDead = true;
		}
		else if(isDead == true && !anim.IsPlaying("Death"))
		{
            if (this.gameObject.CompareTag("spider1"))
            {
				GameManager.Instance.spiders1OnGame -= 1;
				GameManager.Instance.playerXP += 10;
			} else if (this.gameObject.CompareTag("spider2"))
			{
				GameManager.Instance.spiders2OnGame -= 1;
				GameManager.Instance.playerXP += 35;
			}
			else if (this.gameObject.CompareTag("spiderBoss"))
			{
				GameManager.Instance.playerXP += 7500;
				battery.SetActive(true);
			}
			Destroy(gameObject);
        } 




	}

	void OnTriggerEnter(Collider colisor)
	{
		if (colisor.gameObject.tag == "Player" && HP > 0 && Input.GetButtonDown("AttackPunch"))
		{
			isOnPlayerAttackRange = true;
			Damage();
		}else if(HP == 0)
        {
			Die();
        }
	}

	void AttackDelay()
    {
		attackCoolDown = false;
    }
	

}
