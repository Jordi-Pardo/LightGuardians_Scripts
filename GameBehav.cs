using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehav : MonoBehaviour {
    public float currentEnergy;
    public float MAXENERGY;
    public GameObject losePanel;
    public GameObject fade;
    public int numMuertos;
    public bool youLose;
    public bool mandoSelected;
	// Use this for initialization
	void Start () {
        currentEnergy = 0;
        MAXENERGY = 100;
        numMuertos = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (numMuertos>= 2)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
            youLose = true;
        }
	}

    public void CargarEnergia ()
    {
        if (currentEnergy < MAXENERGY)
        {
            currentEnergy += 20;
        }

        if (currentEnergy >= MAXENERGY)
        {
            losePanel.SetActive(true);
            youLose = true;
        }
    }
}
