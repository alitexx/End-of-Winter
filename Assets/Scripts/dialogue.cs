using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogue : MonoBehaviour
{
    public CanvasGroup dialoguebox;
    public TextMeshProUGUI dialoguetext;
    // Start is called before the first frame update
    void Start()
    {
        dialoguetext.text = "I AM CHANGING THE TEXT!!";
    }
}
