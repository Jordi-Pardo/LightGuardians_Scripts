using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour {
    PlayerHealth playerHealth;
    public AudioClip heal, energy;
    public AudioSource collectedSounds;
    public float energyAmount;
    public int energyMAX_Amount; 
	// Use this for initialization
	void Awake () {
        playerHealth = GetComponent<PlayerHealth>();
        collectedSounds = GetComponent<AudioSource>();
        energyMAX_Amount = 100;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "heal")
        {
            PlaySound(heal, collectedSounds);
            playerHealth.currentVida = playerHealth.VIDAMAX_PLAYER;
            DestroyObject(other.gameObject);
        }
        if (other.tag == "energy" && energyAmount != energyMAX_Amount)
        {
            PlaySound(energy, collectedSounds);
            DestroyObject(other.gameObject);
            if (energyAmount >= energyMAX_Amount)
            {
                return;
            }
            else
            {
                energyAmount += 5;
            }
        }
    }

    void PlaySound(AudioClip clip, AudioSource source)
    {
        collectedSounds.clip = clip;
        source.Play();
    }
}
