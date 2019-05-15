using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour {
    public Animator anim;
	// Use this for initialization
	void Start () {

        anim = this.GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            anim.SetBool("open", true);
            Debug.Log("Detected");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            anim.SetBool("open", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            anim.SetBool("open", false);
            Debug.Log("Salido");
        }
    }
}
