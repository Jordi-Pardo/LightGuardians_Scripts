using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDetection : MonoBehaviour {
    public GameBehav gameBehav;
    
    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void OnTriggerEnter(Collider other)
    {
         if (other.tag == "Shajhor" && other.GetComponent<EnemyBehav>().energyCharged)
        {
            gameBehav.CargarEnergia();
            Destroy(other.gameObject);
        }
    }
}
