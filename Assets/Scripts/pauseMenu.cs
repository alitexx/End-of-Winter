using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public CanvasGroup pauseMenuCG;
    public CanvasGroup fadeOut;
    public playerController player;
    //just so players cant keep on opening and closing the pause menu 1000000 times
    private bool changingPauseStatus = false;
    //add something for music

    public void title()
    {
        // Tween in black screen
        //tween out music
        changingPauseStatus = false;
        fadeOut.DOFade(1, 2).OnComplete(() => { SceneManager.LoadScene("Title"); });
    }

    public void quitGame()
    {
        // Tween in black screen
        //tween out music
        changingPauseStatus = false;
        fadeOut.DOFade(1, 2).OnComplete(() => { Application.Quit(); });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (changingPauseStatus != true && pauseMenuCG.alpha == 0)
            {
                openPause();
            } else if (changingPauseStatus != true && pauseMenuCG.alpha == 1)
            {
                closePause();
            }
        }
    }

    public void openPause()
    {
        changingPauseStatus = true;
        player.isfrozen = true;
        pauseMenuCG.DOFade(1, 1).OnComplete(() => { changingPauseStatus = false;});
    }

    public void closePause()
    {
        changingPauseStatus = true;
        player.isfrozen = false;
        pauseMenuCG.DOFade(0, 1).OnComplete(() => { changingPauseStatus = false; });
    }
}
