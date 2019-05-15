using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    [SerializeField]
    private float player1FillAmount,player2FillAmount, enemyFillAmount ;
    [SerializeField]
    private Image player1Health, player2Health, enemyBar;
    [SerializeField]
    private GameObject player1, player2, enemy;
    [SerializeField]
    public PlayerHealth player1script, player2script;
    public GameBehav gameBehav;

    // Update is called once per frame
    private float lerpSpeed;

    private void Awake()
    {
        lerpSpeed = 5f;
        player1script = player1.GetComponent<PlayerHealth>();
        player2script = player2.GetComponent<PlayerHealth>();
        gameBehav = enemy.GetComponent<GameBehav>();

       
    }
    void Update () {
        player1FillAmount = (player1script.currentVida) / 100;
        player2FillAmount = (player2script.currentVida) / 100;
        enemyFillAmount = (gameBehav.currentEnergy) / 100;



        player1Health.fillAmount = Mathf.Lerp(player1Health.fillAmount, player1FillAmount, lerpSpeed * Time.deltaTime);
        player2Health.fillAmount = Mathf.Lerp(player2Health.fillAmount, player2FillAmount, lerpSpeed * Time.deltaTime);
        enemyBar.fillAmount = Mathf.Lerp(enemyBar.fillAmount, enemyFillAmount, lerpSpeed * Time.deltaTime);

    }
}
