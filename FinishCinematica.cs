using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishCinematica : MonoBehaviour {
    public Animator anim;
	// Use this for initialization
	void Start () {
		Invoke ("changeScene", 68f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            //changeScene();
            anim.SetTrigger("FadeIn");
        }
	}

	public void changeScene (){
		SceneManager.LoadScene (1);
	}

}
