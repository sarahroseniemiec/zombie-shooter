using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour {
    public static scoreManager instance;
    public int score;
    private Text text;
	// Use this for initialization
	void Start () {
        instance = this;
        text = GetComponent<Text>();
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Score: " + score;
        if (score >= 100)
        {
            zombieController.gameIsOver = true;
        }
    }

  
     public void Increase(int num) {
        score += num;
        
    }
}
