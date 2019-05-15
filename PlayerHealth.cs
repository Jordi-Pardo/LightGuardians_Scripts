using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int VIDAMAX_PLAYER = 100;
    public float currentVida;
    public bool isDead;
    public Animator anim;
    public SphereCollider handCollider;
    public GameObject enemy;
    public AudioClip hit, die;
    public AudioSource sounds;
    public PlayerMovement playerMovement;
    public GameBehav gameBehav;
    public GameObject healthParticles;

    public bool healingZone;
    // Use this for initialization
    private void Awake()
    {
        currentVida = VIDAMAX_PLAYER;
        anim = this.GetComponent<Animator>();
        playerMovement = this.GetComponent<PlayerMovement>();
        isDead = false;

    }

    // Update is called once per frame
    void Update()
    {

        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "healthZone")
        {
            healthParticles.SetActive(true);
            healingZone = true;
            StartCoroutine(AddHealth());
            
        }
        if (other.tag == "EnemySword")
        {
            if (currentVida > 0)
            {
                anim.SetTrigger("damaged");
                currentVida -= 15;
                CheckIfIDie();
            }

        }


        //if (other.tag == "laser")
        //{
        //    if (currentVida > 0)
        //    {
        //        anim.SetTrigger("damaged");
        //        Destroy(other.gameObject);
        //        currentVida -= 10;
        //    }
        //    if (currentVida <= 0)
        //    {
        //        if (!isDead)
        //        {
        //            anim.SetTrigger("isDead");
        //            isDead = true;
        //            playerMovement.isDead = true;
        //            gameBehav.numMuertos++;

        //        }
        //        Invoke("Die", 2f);
        //    }
        //}
    }
    public void CheckIfIDie()
    {
        if (currentVida <= 0)
        {
            isDead = true;
            anim.SetTrigger("isDead");
            Invoke("Die", 1.5f);
            gameBehav.numMuertos++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "healthZone")
        {
            healthParticles.SetActive(false);
            healingZone = false;
            StopCoroutine(AddHealth());
        }
    }
    void Die()
    {

        DestroyObject(this.gameObject);
    }
    IEnumerator AddHealth()
    {
        while (healingZone)
        { // loops forever...
            if (currentVida < VIDAMAX_PLAYER)
            { // if health < 100...
                currentVida += 1; // increase health and wait the specified time
                yield return new WaitForSeconds(0.2f);
            }
            else
            { // if health >= 100, just yield 
                yield return null;
            }
        }


    }
}
