using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public const int MAX_VIDA = 100;
    public  Animator anim;
    public  int currentVida;
    public static EnemyBehav enemyBehav;
    public  AudioClip dieAudio;
    public   AudioSource enemySounds;
    public bool isDead;



    // Use this for initialization
    public void Awake () {
        currentVida = MAX_VIDA;
        anim = this.GetComponent<Animator>();
        enemyBehav = this.GetComponent<EnemyBehav>();
        enemySounds = this.GetComponent<AudioSource>();
        isDead = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}



    public void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.tag == "Fireball")
        {
            DestroyObject(collision.gameObject);
            QuitarVida();
            
        }
    }

    public void QuitarVida()
    {
        if (currentVida > 0) { 
        currentVida -= 50;
            anim.SetTrigger("hitted");
            
        Debug.Log(currentVida);
    }

        if (currentVida <= 0)
        {
            enemySounds.clip = dieAudio;
            enemySounds.Play();
            isDead = true;
        }
    }
}
