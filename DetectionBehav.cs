using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionBehav : MonoBehaviour {

    public PlayerMovement playerMovement;
    public GameObject player;
	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            playerMovement.enemyDetected = true;
            Debug.Log("Enemy enterDetected");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if ( other.tag == "Enemy")
        {
            playerMovement.enemyDetected = false;
            Debug.Log("Enemy out of range");
        }
    }
}
