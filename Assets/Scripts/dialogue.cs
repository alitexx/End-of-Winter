using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class dialogue : MonoBehaviour
{
    public RectTransform dialoguebox;
    public RectTransform dialoguetexttransform;
    public Vector2 dialoguesize;
    public Vector2 textsize;
    public GameObject pos;
    public TextMeshProUGUI dialoguetext;
    // Start is called before the first frame update
    void Start()
    {
        //dialoguetext.text = "I AM CHANGING THE TEXT!!";
    }

    public void runDialogue()
    {
        dialoguebox.DOMove(pos.transform.position, 0.25f, true);
        dialoguebox.DOSizeDelta(dialoguesize, 0.5f, true);
        dialoguetexttransform.DOSizeDelta(textsize, 0.5f, true);
        dialoguetext.text = "I AM CHANGING THE TEXT!!";
    }
}
