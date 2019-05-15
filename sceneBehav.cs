using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneBehav : MonoBehaviour {
    public GameObject loadingScreen;
    public Slider slider;
    public GameObject loadingImage;
    public GameObject text;

    private void Start()
    {
        PlayScene(1);
    }
    public void PlayScene(int num)
    {
        StartCoroutine(LoadAsynchronously(num));
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator LoadAsynchronously (int num)
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(num);

        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {



            slider.value = 0.9f;
            StartCoroutine(Wait(40f, operation));
            yield return null;
        }
    }

    IEnumerator Wait(float time,  AsyncOperation operation)
    {
        yield return new WaitForSeconds(time);
        loadingImage.SetActive(false);
        text.SetActive(true);
        slider.value = 1;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            operation.allowSceneActivation = true;
        }


    }
}
