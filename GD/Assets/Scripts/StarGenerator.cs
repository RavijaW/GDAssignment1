using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public GameObject StarGO;
    public int MaxStars;
    // Start is called before the first frame update
    void Start()
    {
       Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
       Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

       for(int i = 0; i <MaxStars; ++i)
       {
           GameObject star = (GameObject)Instantiate(StarGO);

           star.transform.position = new Vector2(Random.Range(min.x,max.x),Random.Range(min.y, max.y));

           star.transform.parent = transform;
       } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
