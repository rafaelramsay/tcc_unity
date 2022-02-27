using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpider1 : MonoBehaviour
{
    public GameObject spider1Prefab;
    public float SpawnTime = 120.0f;
    public SpiderScript Spider;
    private float xPos;
    private float zPos;
    private int isHungrySpider;
    public GameObject hungrySpiderPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }
    void SpawnSpider()
    {
        xPos = Random.Range(260.2f, 852f);
        zPos = Random.Range(-131f, -829f);
        isHungrySpider = Random.Range(1, 100);
        if(isHungrySpider == 69)
        {
            GameObject hungrySpider = Instantiate(hungrySpiderPrefab) as GameObject;
            hungrySpider.transform.position = new Vector3(xPos, 0.66f, zPos);
            GameManager.Instance.spiders1OnGame += 1;
        }
        else
        {
            GameObject spider1 = Instantiate(spider1Prefab) as GameObject;
            spider1.transform.position = new Vector3(xPos, 0.66f, zPos);
            GameManager.Instance.spiders1OnGame += 1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnTime);
            if(GameManager.Instance.spiders1OnGame < 5)
            {
                SpawnSpider();
            }
            
        }
        
    }
}
