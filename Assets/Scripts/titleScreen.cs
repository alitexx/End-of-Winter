using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class titleScreen : MonoBehaviour
{
    public CanvasGroup credits;
    public CanvasGroup fadeOut;
    public CanvasGroup xButton;
    [SerializeField] private AudioSource confirm;
    [SerializeField] private AudioSource cancel;
    [SerializeField] private AudioSource bgm;


    private void Start()
    {
        fadeOut.DOFade(0, 1);
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
        xButton.DOFade(1, 1);
        credits.DOFade(1, 1);
        //tween in credits
    }

    public void closeCredits()
    {
        cancel.Play();
        xButton.DOFade(0, 1);
        credits.DOFade(0, 1);
        //tween out credits
    }
}
