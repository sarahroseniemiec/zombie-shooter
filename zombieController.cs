using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class zombieController : MonoBehaviour {

    //public event System.Action OnGameWin;

    private UnityEngine.AI.NavMeshAgent nav;
    public Transform barrel;
    public int health = 3;
    int count;
    bool zombieDead = false;
    public static bool gameIsOver;
    GameObject[] spawners;
  
    // Use this for initialization
    void Start () {
        
      
       
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        nav.destination = barrel.transform.position;
        count = 0;

        spawners = GameObject.FindGameObjectsWithTag("zSpawner");
    
	}
	
	// Update is called once per frame
	void Update () {

        if (zombieDead) {
            nav.destination = gameObject.transform.position;
        }

        else if (count % 10 == 0) {
            nav.destination = barrel.transform.position;
        }
        count++;

        if (gameIsOver) {
            foreach (GameObject spawner in spawners) {
                Destroy(spawner);
            }
        }
        
	
	}

    public void decrease()
    {
        if(health >1)
        {
            health--;
      
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("isDead", true);
            zombieDead = true;
            nav.destination = gameObject.transform.position;
            scoreManager.instance.Increase(1);
            StartCoroutine(destroyZombie());
        }

    }

    IEnumerator destroyZombie() {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
