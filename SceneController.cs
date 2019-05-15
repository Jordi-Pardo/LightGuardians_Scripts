using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneController : MonoBehaviour {

    public int currentScene;
    public Animator anim;
    public GameBehav gameBehav;
    public GameObject fade;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        Time.timeScale = 1;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExitApp()
    {
        Application.Quit();
    }

    public void ChangeToScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneManager.LoadScene(1);
        }
        if (gameBehav == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            return;
        }

            if (gameBehav.youLose)
        {


            SceneManager.LoadScene(1);
        }
        else if (gameBehav != null )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        
    }

    public void ChangeToSceneMainMenu()
    {
        SceneManager.LoadScene(1);

    }
    public void FadeToLevel()
    {
        anim.SetTrigger("FadeIn");
        Invoke("ChangeToScene", 1f);
    }
    public void FadeIn()
    {
        anim.SetTrigger("FadeIn");
    }
    public void FadeOut()
    {
        anim.SetTrigger("FadeOut");
    }



    public int CheckCurrentScene()
    {

        currentScene = SceneManager.GetActiveScene().buildIndex;
        return currentScene;
    }
    public void ActiveFade()
    {
        fade.SetActive(true);
    }
    public void DesactiveFade()
    {
        fade.SetActive(false);
    }

}
