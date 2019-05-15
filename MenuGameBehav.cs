using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameBehav : MonoBehaviour {

    public void LoadScene(int num)
    {
        SceneManager.LoadScene(num);
    }
public void Quit()
    {
        Application.Quit();
    }
}
