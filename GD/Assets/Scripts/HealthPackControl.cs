using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPackControl : MonoBehaviour
{

    public GameObject HealGO;
    float speed;
    GameObject livesUITextGO;

    
    // Start is called before the first frame update
    void Start()
    {
        speed =2f;
        livesUITextGO = GameObject.FindGameObjectWithTag("LivesTextTag");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2 (position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        
        
        if(transform.position.y<min.y)
        {
            Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerSipTag" ))
        {
            PlayHeal();
            Destroy(gameObject);
            livesUITextGO.GetComponent<GameHealth>().Health+=1;
            
        }
    }

    void PlayHeal()
    {
        GameObject heal = (GameObject)Instantiate(HealGO);

        heal.transform.position = transform.position;
    }
     
}
