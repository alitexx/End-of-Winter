using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;
using DG.Tweening;

public class dialogue : MonoBehaviour
{
    public RectTransform dialoguebox;
    public RectTransform dialoguetexttransform;
    public typewriterEffect typewriter;
    public Vector2 dialoguesize;
    public Vector2 textsize;
    public GameObject pos;
    public GameObject initpos;
    public TextMeshProUGUI dialoguetext;
    private int[] alreadyUsedDialogue;
    private string[] dialogueSpoken;
    private bool isTextDone = false;
    private int currentDialoguePlacement = 0;
    private GameObject originalLoc;

    // Start is called before the first frame update
    void Start()
    {
        //dialoguetext.text = "I AM CHANGING THE TEXT!!";
        alreadyUsedDialogue = new int[5];
        dialogueSpoken = new string[5];
        typewriterEffect.CompleteTextRevealed += HandleTextRevealed;
    }

    public void HandleTextRevealed()
    {
        isTextDone = true;
    }


    private void Update()
    {
        if(isTextDone && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))){
            isTextDone = false;
            if (currentDialoguePlacement > dialogueSpoken.Length || dialogueSpoken[currentDialoguePlacement] == "END")
            {
                dialogueSpoken = new string[1];
                isTextDone = false;
                currentDialoguePlacement = 0;
                typewriter.enabled = false;
                closeDialogue();
                return;
            }
            Debug.Log(currentDialoguePlacement);
            dialoguetext.text = dialogueSpoken[currentDialoguePlacement];
            currentDialoguePlacement++;
        }
    }

    public void runDialogue(GameObject originalLocation)
    {
        originalLoc = originalLocation;
        dialoguebox.DOMove(pos.transform.position, 0.25f, true);
        dialoguebox.DOSizeDelta(dialoguesize, 0.5f, true);
        dialoguetexttransform.DOSizeDelta(textsize, 0.5f, true);
        findLines(1);
    }

    private void findLines(int random)
    {
        for (int i = 0; i < alreadyUsedDialogue.Length; i++)
        {
            if (alreadyUsedDialogue[i] == random)
            {
                findLines((UnityEngine.Random.Range(1, 10)));
            }
        }

        alreadyUsedDialogue[1] = random;

        dialogueSpoken[0] = "I am talking so much i am talking so much i am talking so much I am talking so much i am talking so much i am talking so much i am talkign so much i am talkign so much I am talking so much i am talking so much i am talking so much i am talkign so much ";
        dialogueSpoken[1] = "do you talk a lot too?";
        dialogueSpoken[2] = "me want hamburger";
        dialogueSpoken[3] = "END";
        typewriter.enabled = true;
        dialoguetext.text = dialogueSpoken[0];
        currentDialoguePlacement++;

        switch (random)
        {
            case 1:
                dialogueSpoken[0] = "Hello!";
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                break;
            case 12:
                break;
            case 13:
                break;
            case 14:
                break;
        }
    }
        


    public void closeDialogue()
    {
        dialoguebox.DOMove(initpos.transform.position, 0.25f, true);
        dialoguebox.DOSizeDelta(new Vector2(25, 15), 0.5f, true);
        dialoguetexttransform.DOSizeDelta(new Vector2(22, 13.5f), 0.5f, true);
        originalLoc.GetComponent<triggerEvent>().finishUpDoor();
    }
}
