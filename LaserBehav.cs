using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehav : MonoBehaviour {
    public Rigidbody rb;
    public float speed;
    public PlayerHealth playerHealth;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        

		
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = this.transform.forward * 10000f *  Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Escudo")
        {
            Destroy(this.gameObject);
        }
        if (other.tag == "Player" || other.tag == "Player2")
        {
            playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth.currentVida > 0)
            {
                playerHealth.anim.SetTrigger("damaged");
                playerHealth.currentVida -= 10;
                playerHealth.CheckIfIDie();
            }
            
            Destroy(this.gameObject);
        }
        
        
    }
}
