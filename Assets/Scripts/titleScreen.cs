using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class titleScreen : MonoBehaviour
{
    public CanvasGroup credits;
    public CanvasGroup fadeOut;
    public CanvasGroup winScreen;
    public CanvasGroup mainmenubuttonWinScreen;
    public CanvasGroup xButton;
    [SerializeField] private AudioSource confirm;
    [SerializeField] private AudioSource cancel;
    [SerializeField] private AudioSource bgm;


    private void Start()
    {
        fadeOut.DOFade(0, 1);
        xButton.enabled = false;
        if (winCondition.flowersGiven >= 5)
        {
            //display you win stuff
            mainmenubuttonWinScreen.enabled = false;
            mainmenubuttonWinScreen.DOFade(1, 0.25f);
            winScreen.DOFade(1, 0.25f);
        }
        winCondition.flowersGiven = 0;
    }

    public void closeWinScreen()
    {
        // Tween in black screen
        confirm.Play();
        mainmenubuttonWinScreen.DOFade(0, 1).OnComplete(() => { mainmenubuttonWinScreen.enabled = false; });
        winScreen.DOFade(0, 1);
    }

    public void startGame()
    {
        // Tween in black screen
        confirm.Play();
        bgm.DOFade(0, 1);
        fadeOut.DOFade(1, 1).OnComplete(() => { SceneManager.LoadScene("Game"); });
    }
    
    public void quitGame()
    {
        // Tween in black screen
        confirm.Play();
        fadeOut.DOFade(1, 1).OnComplete(() => { Application.Quit(); });
    }

    public void openCredits()
    {
        confirm.Play();
        xButton.enabled = true;
        xButton.DOFade(1, 1);
        credits.DOFade(1, 1);
        //tween in credits
    }

    public void closeCredits()
    {
        cancel.Play();
        xButton.DOFade(0, 1).OnComplete(() => { xButton.enabled = false; });
        credits.DOFade(0, 1);
    }
}
