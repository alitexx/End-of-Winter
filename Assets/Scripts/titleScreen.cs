using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class titleScreen : MonoBehaviour
{
    public CanvasGroup credits;
    public CanvasGroup fadeOut;

    public void startGame()
    {
        // Tween in black screen
        fadeOut.DOFade(1, 2).OnComplete(() => { SceneManager.LoadScene("Game"); });
    }
    
    public void quitGame()
    {
        // Tween in black screen
        fadeOut.DOFade(1, 2).OnComplete(() => { Application.Quit(); });
    }

    public void openCredits()
    {
        credits.DOFade(1, 2);
        //tween in credits
    }

    public void closeCredits()
    {
        credits.DOFade(0, 2);
        //tween out credits
    }
}
