using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoorDetection : MonoBehaviour {
    public Animator anim;

    public bool pickedUpOrange;
    public bool pickedUpBlue;
    public SceneController sceneController;

    // Use this for initialization
    void Start () {
        anim = this.GetComponent<Animator>();		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
		if (pickedUpBlue && pickedUpOrange) {
			anim.SetTrigger ("openDoor");
            sceneController.Invoke("FadeToLevel", .8f);

		
		}
    }
}


