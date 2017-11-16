using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunManager : MonoBehaviour {
   
    public SteamVR_TrackedObject trackedObj;
    public Rigidbody bulletPrefab;
    public Transform firePosition;
    public AudioClip shotSound;
    AudioSource audio;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {

        Rigidbody bulletInstance;
        SteamVR_Controller.Device controller = SteamVR_Controller.Input((int)trackedObj.index);

        if (controller.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)) {
            controller.TriggerHapticPulse(3000);
            bulletInstance = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation) as Rigidbody;
            bulletInstance.AddForce(firePosition.forward * 2000);
            audio.PlayOneShot(shotSound, 0.7f);

        }
    }
}
