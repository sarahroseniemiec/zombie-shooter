using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletManager : MonoBehaviour {

    public GameObject bloodSplatter;


    void OnTriggerEnter(Collider co)
    {
       
        if (co.tag == "Zombie")
        {
            //Destroy(co.gameObject);
            co.gameObject.GetComponent<Animator>().SetBool("isHit", true);
            co.gameObject.GetComponent<zombieController>().decrease();
            GameObject bloodSplat = Instantiate(bloodSplatter, co.transform.position, Quaternion.identity) as GameObject;
          
            //Transform bloodTransform = gameObject.transform;
            //bloodSplatter.transform.position = bloodTransform.position;
            //ParticleSystem.EmissionModule bloodSplatterEmissionModule = bloodSplatter.emission;
            //bloodSplatterEmissionModule.enabled = true;
        }
    }

    private void OnTriggerExit(Collider co)
    {
        co.gameObject.GetComponent<Animator>().SetBool("isHit", false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ricochet")
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 reflect = Vector3.Reflect(transform.forward, contact.normal);
            float rotation = 90 - Mathf.Atan2(reflect.z, reflect.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rotation, 0);

            Debug.Log("bullet manageer collision");


        }
    



    }




    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
