using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject zombiePrefab;
    public Transform target;
    public float interval = 3;
    zombieController zombieScript;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnNext", interval, interval);
        //zombieScript = GetComponent<zombieController>();
    }
    void SpawnNext() {
        var x = transform.position;
        var zRand = Random.Range(-34.0f, -3.0f);
        x.z = zRand;
        
        GameObject zombie = Instantiate(zombiePrefab, x, Quaternion.identity) as GameObject;
        zombieScript = zombie.GetComponent<zombieController>();
        //zombie.GetComponent<Transform>().barrel = target;
        zombieScript.barrel = target;

    }
	// Update is called once per frame
	void Update () {
		
	}
}
