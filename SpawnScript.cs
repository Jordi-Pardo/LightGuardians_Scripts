using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnScript : MonoBehaviour {
    public Transform [] spawnPoints;
    public GameObject[] aliens;
    public float timeSpawn;
    public GameObject waveBehav;
    public GameObject waveTitle;
    public Text title;
    public Animator anim;
    public bool sent;
	// Use this for initialization
	void Start () {
        title = waveTitle.  GetComponent<Text>();
        anim = waveBehav.GetComponent<Animator>();
        Invoke("FirstWave", 0);
        Invoke("SecondWave", 20f);
        Invoke("ThirdWave", 40);
        Invoke("FourthWave", 80f);
        Invoke("FifthWave", 120f);
        InvokeRepeating("SpawnRandom", 150, timeSpawn);

    }

    // Update is called once per frame
    void Update () {
		
	}

    void SpawnRandom()
    {   if (!sent)
            anim.SetTrigger("startTitle");
        title.text = "Survive until end!";
        
        int aliensNum = Random.Range(0, aliens.Length);
        int spawnPointsIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(aliens[aliensNum], spawnPoints[spawnPointsIndex].position, spawnPoints[spawnPointsIndex].rotation);
        Debug.Log(aliensNum + "És el enemigo: " + aliens[aliensNum].name);
        sent = true;
    }

    public void FirstWave()
    {
        title.text = "First Wave";
        Instantiate(aliens[2], spawnPoints[0].position, spawnPoints[0].rotation);
        Instantiate(aliens[2], spawnPoints[1].position, spawnPoints[0].rotation);
    }

    public void SecondWave()
    {
        title.text = "Second Wave";
        anim.SetTrigger("startTitle");
        Instantiate(aliens[2], spawnPoints[0].position, spawnPoints[0].rotation);
        Instantiate(aliens[2], spawnPoints[1].position, spawnPoints[0].rotation);
        Instantiate(aliens[0], spawnPoints[1].position, spawnPoints[0].rotation);
    }

    public void ThirdWave()
    {
        title.text = "Third Wave";
        anim.SetTrigger("startTitle");
        Instantiate(aliens[2], spawnPoints[0].position, spawnPoints[0].rotation);
        Instantiate(aliens[0], spawnPoints[1].position, spawnPoints[0].rotation);
        Instantiate(aliens[1], spawnPoints[0].position, spawnPoints[0].rotation);
    }
    public void FourthWave()
    {
        title.text = "Fourth Wave";
        anim.SetTrigger("startTitle");
        Instantiate(aliens[1], spawnPoints[1].position, spawnPoints[0].rotation);
        Instantiate(aliens[1], spawnPoints[0].position, spawnPoints[0].rotation);
    }

    public void FifthWave()
    {
        title.text = "Fifth Wave";
        anim.SetTrigger("startTitle");
        Instantiate(aliens[0], spawnPoints[1].position, spawnPoints[0].rotation);
        Instantiate(aliens[0], spawnPoints[1].position, spawnPoints[0].rotation);
        Instantiate(aliens[1], spawnPoints[0].position, spawnPoints[0].rotation);
        Instantiate(aliens[2], spawnPoints[0].position, spawnPoints[0].rotation);
    }
}
