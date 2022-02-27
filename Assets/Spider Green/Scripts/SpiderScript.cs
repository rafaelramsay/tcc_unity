using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour{
	
	public float maxRange = 30f;
    public float maxEatRange = 2.5f;
    private float currentRange;
    private float currentFoodRange;
    public Transform player;
	Animation anim;
	public GameObject battery;
	public int maxHP;
	
	public float spiderSpeed = 4f;
	
	//Attack
	private BoxCollider areaAttack;
	private bool attacking =  false;
	public float attackRange = 8f;

	//Damage
	public bool isDead = false;


	//HP
	public int hp = 100;

	private bool isOnPlayerAttackRange = false;

	private bool attackCoolDown = false;

    public GameObject meat;

    public PlayerScript playerScript;
    public GameObject hungryIcon;
    public GameObject loveIcon;
    public bool isTamed;
    
   



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
		areaAttack = GetComponent<BoxCollider>();
		
		player = GameObject.FindGameObjectWithTag("Player").transform;
        

        playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isMeatActive == true)
        {
            meat = GameObject.FindGameObjectWithTag("Meat");
        }
        

        if (isOnPlayerAttackRange == true && hp > 0 && Input.GetButtonDown("AttackPunch") && attackCoolDown == false)
        {
			Damage();
        }else if(hp <= 0)
        {
			Die();
        }

        if(attackCoolDown == true)
        {
            Invoke(nameof(AttackDelay), 3.833f);
        }
        if (gameObject.CompareTag("HungrySpider"))
        {
            
            
           if(currentRange >= maxRange && !anim.IsPlaying("Death") && GameManager.Instance.isMeatActive == true)
            {
                anim.Play("Walk");
                transform.LookAt(meat.transform);
                transform.position += transform.forward * spiderSpeed * Time.deltaTime;
                if(currentFoodRange <= maxEatRange)
                {
                    loveIcon.SetActive(true);
                    hungryIcon.SetActive(false);
                    meat.SetActive(false);
                    isTamed = true;
                    GameManager.Instance.isMeatActive = false;
                    GameManager.Instance.spiderImage.SetActive(true);
                }
            }
        }
		

		attacking = anim.IsPlaying("Attack");
		areaAttack.enabled = anim.IsPlaying("Attack");
		
	    currentRange = Vector3.Distance(transform.position, player.transform.position);

        if(GameManager.Instance.isMeatActive == true)
        {
            currentFoodRange = Vector3.Distance(transform.position, meat.transform.position);
        }
        


        if (currentRange <= attackRange && isTamed == false){
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
		hp -= GameManager.Instance.playerDamage;
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
                playerScript.meat += 3;
			} else if (this.gameObject.CompareTag("spider2"))
			{
				GameManager.Instance.spiders2OnGame -= 1;
				GameManager.Instance.playerXP += 35;
                playerScript.meat += 7;
            }
			else if (this.gameObject.CompareTag("spiderBoss"))
			{
				GameManager.Instance.playerXP += 7500;
				battery.SetActive(true);
                playerScript.meat += 135;
            }
			Destroy(gameObject);
        } 




	}

	void OnTriggerEnter(Collider colisor)
	{
		if (colisor.gameObject.tag == "Player")
		{
			isOnPlayerAttackRange = true;
		
		}
    }

	void AttackDelay()
    {
		attackCoolDown = false;
    }




	private void OnTriggerExit(Collider colisor)
	{
		if (colisor.gameObject.tag == "Player")
		{
			isOnPlayerAttackRange = false;
		}
	}


    
}
