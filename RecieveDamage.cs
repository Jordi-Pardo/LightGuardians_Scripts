using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveDamage : MonoBehaviour {

    public Animator anim;
    public EnemyHealth enemyHealth;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword")
        {
                enemyHealth.currentVida -= 50;
                anim.SetTrigger("Damaged");
                Debug.Log("Recibí daño de la espada!");
                Debug.Log("Current Health: " + enemyHealth.currentVida);
                CheckIfIDie();
            


        }

        if (other.tag == "SwordArea")
        {
           
                enemyHealth.currentVida -= 100;
                anim.SetTrigger("Damaged");
                Debug.Log("Area Damage");
                Debug.Log("Current Health: " + enemyHealth.currentVida);
                CheckIfIDie();
            

        }

    }
    public void CheckIfIDie()
    {
        if (enemyHealth.currentVida <= 0)
        {
            enemyHealth.isDead = true;
            anim.SetTrigger("Dead");

        }
    }


}
