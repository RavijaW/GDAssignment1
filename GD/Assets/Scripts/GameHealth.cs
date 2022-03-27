using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHealth : MonoBehaviour
{

    Text livesUIText;
    int lives;

     public int Health
    {
        get
        {
            return this.lives;
        }
        set
        {
            this.lives = value;
            UpdatelivesTextUI(); 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        livesUIText = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void UpdatelivesTextUI()
    {
        string livesStr = string.Format("{00}",lives);
        livesUIText.text = livesStr;
    }
}
