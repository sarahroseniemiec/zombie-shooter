using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class winZombies : MonoBehaviour {
    
    public GameObject winZombiePrefab;
    int zCount = 0;
    AudioSource audio;
    //zombieController zombieScript;

    // Use this for initialization
    void Start ()
    {
        audio = gameObject.GetComponent<AudioSource>();
     

    }

    void onWin() {
  


        var x = transform.position;
        while (zCount < 5) {
            GameObject zombie = Instantiate(winZombiePrefab, x, Quaternion.identity) as GameObject;
            zombie.GetComponent<Animator>().SetBool("isGameOver", true);
            zCount++;
        }
        if (!audio.isPlaying)
        {
            audio.Play();
        }
     
    }
	
	// Update is called once per frame
	void Update () {
        


        if (zombieController.gameIsOver) {
            
            onWin();

            zombieController.gameIsOver = false;
        }
	}
}
