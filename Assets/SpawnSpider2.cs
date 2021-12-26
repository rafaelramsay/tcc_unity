using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpider2 : MonoBehaviour
{
    public GameObject spider2Prefab;
    public float SpawnTime = 120.0f;
    public SpiderScript Spider;
    private float xPos;
    private float zPos;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }
    void SpawnSpider()
    {
        xPos = Random.Range(260.2f, 852f);
        zPos = Random.Range(-131f, -829f);
        GameObject spider2 = Instantiate(spider2Prefab) as GameObject;
        spider2.transform.position = new Vector3(xPos, 0.66f, zPos);
        GameManager.Instance.spiders2OnGame += 1;
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
            if(GameManager.Instance.spiders2OnGame < 5)
            {
                SpawnSpider();
            }
            
        }
        
    }
}
