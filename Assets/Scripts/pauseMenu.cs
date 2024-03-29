using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public CanvasGroup pauseMenuCG;
    public CanvasGroup pauseMenuButtons;
    public CanvasGroup fadeOut;
    public GameObject pauseButtons;
    public playerController player;
    public bool pauseOpen;
    //just so players cant keep on opening and closing the pause menu 1000000 times
    private bool changingPauseStatus = false;
    [SerializeField] private AudioSource confirm;
    [SerializeField] private AudioSource cancel;
    [SerializeField] private AudioSource bgm;
    //add something for music

    public void title()
    {
        confirm.Play();
        bgm.DOFade(0, 1);
        changingPauseStatus = false;
        fadeOut.DOFade(1, 1).OnComplete(() => { SceneManager.LoadScene("Title"); });
    }

    public void quitGame()
    {
        // Tween in black screen
        //tween out music
        confirm.Play();
        bgm.DOFade(0, 1);
        changingPauseStatus = false;
        fadeOut.DOFade(1, 1).OnComplete(() => { Application.Quit(); });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !dialogue.isTalking)
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
        pauseOpen = true;
        changingPauseStatus = true;
        player.isfrozen = true;
        pauseButtons.SetActive(true);
        confirm.Play();
        bgm.DOFade(0.5f, 1);
        pauseMenuButtons.DOFade(1, 1);
        pauseMenuCG.DOFade(1, 1).OnComplete(() => { changingPauseStatus = false;});
    }

    public void closePause()
    {
        changingPauseStatus = true;
        player.isfrozen = false;
        cancel.Play();
        bgm.DOFade(1, 1);
        pauseMenuButtons.DOFade(0, 1);
        pauseMenuCG.DOFade(0, 1).OnComplete(() => { changingPauseStatus = false; pauseOpen = false; pauseButtons.SetActive(false); });
    }
}
