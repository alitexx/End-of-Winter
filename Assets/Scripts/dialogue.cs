using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class dialogue : MonoBehaviour
{
    public static bool isTalking = false;
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
    public GameObject openingCutscene;
    public GameObject headPresent;
    public playerController player;
    public SpriteRenderer other;
    public Sprite otherTurned;
    [SerializeField] private AudioSource CloseDoor;
    [SerializeField] private AudioSource ObtainPresent;
    [SerializeField] private AudioSource bgm;
    [SerializeField] private CanvasGroup fadeOut;
    [SerializeField] private CanvasGroup housesLeft;
    [SerializeField] private TextMeshProUGUI housesLeftText;
    [SerializeField] private Animator playeranim;
    [SerializeField] private Sprite[] giftOptions;

    // Start is called before the first frame update
    void Start()
    {
        fadeOut.DOFade(0, 1);
        alreadyUsedDialogue = new int[5];
        dialogueSpoken = new string[9];
        typewriterEffect.CompleteTextRevealed += HandleTextRevealed;
        runDialogue(openingCutscene);
    }

    public void HandleTextRevealed()
    {
        isTextDone = true;
    }


    private void Update()
    {
        if(isTextDone && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))){
            isTextDone = false;
            if (currentDialoguePlacement == 8)
            {
                other.sprite = otherTurned;
                other.DOFade(0, 1);

                dialogueSpoken = new string[9];
                isTextDone = false;
                currentDialoguePlacement = 0;
                typewriter.enabled = false;
                closeDialogue(false);
                player.isfrozen = false;
                currentDialoguePlacement = 0;
                CloseDoor.Play();
                playeranim.enabled = true;
                isTalking = false;
                housesLeft.DOFade(1, 1);
                return;
            }
            if (currentDialoguePlacement > dialogueSpoken.Length || dialogueSpoken[currentDialoguePlacement] == "END")
            {
                dialogueSpoken = new string[9];
                isTextDone = false;
                currentDialoguePlacement = 0;
                typewriter.enabled = false;
                closeDialogue();
                currentDialoguePlacement = 0;
                CloseDoor.Play();
                winCondition.flowersGiven++;
                housesLeftText.text = $"Houses Left: {winCondition.flowersGiven}";
                if (winCondition.flowersGiven >= 5)
                {
                    //send to another scene
                    headPresent.SetActive(false);
                    bgm.DOFade(0, 1);
                    fadeOut.DOFade(1, 2).OnComplete(() => { SceneManager.LoadScene("Title"); });
                }
                else
                {
                    ObtainPresent.Play();
                    headPresent.GetComponent<SpriteRenderer>().sprite = giftOptions[UnityEngine.Random.Range(0, 9)];
                }
                isTalking = false;
                return;
            }

            if(currentDialoguePlacement == 4 && openingCutscene == originalLoc)
            {
                //enable present on the head
                headPresent.SetActive(true);
                //sfx
                ObtainPresent.Play();
            }

            dialoguetext.text = dialogueSpoken[currentDialoguePlacement];
            currentDialoguePlacement++;
        }
    }

    public void runDialogue(GameObject originalLocation)
    {
        isTalking = true;
        originalLoc = originalLocation;
        dialoguebox.DOMove(pos.transform.position, 0.25f, true);
        dialoguebox.DOSizeDelta(dialoguesize, 0.5f, true);
        dialoguetexttransform.DOSizeDelta(textsize, 0.5f, true);
        if (originalLocation == openingCutscene)
        {
            dialogueSpoken[0] = "Do you even listen? I bet you don't know that you need to press Space to make the story progress, now did you?";
            dialogueSpoken[1] = "Alright, this is the last time I'll tell you. You're helping out the community now! Think of it as turning over a new leaf.";
            dialogueSpoken[2] = "That means that you have to be nice to people now! You can't be a lazybones, put a smile on that face!";
            dialogueSpoken[3] = "And it all starts with one easy step... like giving your neighbors flowers!";
            dialogueSpoken[4] = "Here, take this. I even packaged it up for you! It shouldn't be hard, just go to the houses with green doors and pass them out. There should be five.";
            dialogueSpoken[5] = "Social anxiety or not, you just gotta knock on their door a few times and hand 'em out. I believe in you!";
            dialogueSpoken[6] = "Try the house right next to here, I'm sure they'd appreciate it. Remember, you only need to hand them out to houses with green doors, they all look similar!";
            dialogueSpoken[7] = "Oh! And if you forgot, you gotta move your legs with W, A, S and D. Or you can press escape to take a breather!";
            dialogueSpoken[8] = "END";
            typewriter.enabled = true;
            dialoguetext.text = dialogueSpoken[0];
            currentDialoguePlacement++;
        } else
        {
            findLines((UnityEngine.Random.Range(1, 15)));
        }
    }

    private void findLines(int random)
    {
        for (int i = 0; i < alreadyUsedDialogue.Length; i++)
        {
            if (alreadyUsedDialogue[i] == random)
            {
                findLines((UnityEngine.Random.Range(1, 15)));
            }
        }

        alreadyUsedDialogue[winCondition.flowersGiven] = random;

        //dialogueSpoken[0] = "I am talking so much i am talking so much i am talking so much I am talking so much i am talking so much i am talking so much i am talkign so much i am talkign so much I am talking so much i am talking so much i am talking so much i am talkign so much ";
        //dialogueSpoken[1] = "do you talk a lot too?";
        //dialogueSpoken[2] = "me want hamburger";
        //dialogueSpoken[3] = "END";
        //typewriter.enabled = true;
        //dialoguetext.text = dialogueSpoken[0];
        //currentDialoguePlacement++;

        switch (random)
        {
            case 1:
                dialogueSpoken[0] = "It's a beautiful day outside. Birds are singing, flowers are blooming... On days like these, kids like you...";
                dialogueSpoken[1] = "Wait, you're here to give me flowers? Oh, so you aren't the weird kid throwing rocks in my window.";
                dialogueSpoken[2] = "Neato. Thanks, kid.";
                dialogueSpoken[3] = "END";
                break;
            case 2:
                dialogueSpoken[0] = "Hey hey hey! Welcome to the SUPER FAMOUS AWESOME QUIZ SHOW! I'm your host, Super Famous Awesome Guy. And today's special guest is...";
                dialogueSpoken[1] = "...";
                dialogueSpoken[2] = "QUIET PERSON ON MY FRONT DOOR! Now, if you answer my riddles of three, you'll win a FABULOUS PRIZE!";
                dialogueSpoken[3] = "What? Flowers? For ME? Oh, well, if you insist. Everyone give a huge round of applause for QUIET PERSON AT MY FRONT DOOR!";
                dialogueSpoken[4] = "END";
                break;
            case 3:
                dialogueSpoken[0] = "...Hmph. Flowers? No thanks.";
                dialogueSpoken[1] = "...Well, maybe just one petal. But if I take the petal, I might as well take the leaves. And if I take the leaves, I might as well take the stem. And if I take the stem...";
                dialogueSpoken[2] = "Fine! Just give them to me!";
                dialogueSpoken[3] = "END";
                break;
            case 4:
                dialogueSpoken[0] = "Oh, Flowers? How kind of you!";
                dialogueSpoken[1] = "Thank you so much dearie, this... this has made my week!";
                dialogueSpoken[2] = "END";
                break;
            case 5:
                dialogueSpoken[0] = "Can't you read? The invisible sign on my door clearly states no Gorl Scouts are allowed here! I buy those cookies like a maniac!";
                dialogueSpoken[1] = "You aren't selling cookies? You're giving away flowers? Interesting...";
                dialogueSpoken[2] = "If you insist.";
                dialogueSpoken[3] = "END";
                break;
            case 6:
                dialogueSpoken[0] = "You interrupted my online match! I just lost like... a hundred Gobble points! That's half of a Gooble!";
                dialogueSpoken[1] = "Flowers? In today's age? I guess I'll take some. Thanks!";
                dialogueSpoken[2] = "END";
                break;
            case 7:
                dialogueSpoken[0] = "Meow.";
                dialogueSpoken[1] = "...";
                dialogueSpoken[2] = "(Did a cat just answer the door?)";
                dialogueSpoken[3] = "Meow!";
                dialogueSpoken[4] = "(It seems to enjoy the flowers.)";
                dialogueSpoken[5] = "END";
                break;
            case 8:
                dialogueSpoken[0] = "Hello! Oh, you're selling flowers? They look so pretty! How much?";
                dialogueSpoken[1] = "You're giving them away?! Oh, how kind of you! What a good samaritan.";
                dialogueSpoken[2] = "Thank you so much, I'll be sure to repay you soon. Do you have any allergies? I was planing on making banana walnut bread tonight, and I'd be happy to share!";
                dialogueSpoken[3] = "Thanks again!";
                dialogueSpoken[4] = "END";
                break;
            case 9:
                dialogueSpoken[0] = "Why do you have a box on your head.";
                dialogueSpoken[1] = "It's flowers? It looks like a box to me. A crudely wrapped box with old holiday wrapping paper, to be more specific.";
                dialogueSpoken[2] = "You're asking if I would want some? Haha! As if I would soil my moisturized and manicured fingertips with something so... earthy.";
                dialogueSpoken[3] = "But then again... my spouse loves flowers. I guess I will take some.";
                dialogueSpoken[4] = "END";
                break;
            case 10:
                dialogueSpoken[0] = "I smell it... I smell it...";
                dialogueSpoken[1] = "(???)";
                dialogueSpoken[2] = "YOU! YOU HAVE FOOD! GIVE ME THAT!";
                dialogueSpoken[3] = "END";
                break;
            case 11:
                dialogueSpoken[0] = "What lovely flowers! And you say they are free?";
                dialogueSpoken[1] = "I'll only take a few so you have enough for everyone else. What a surprise!";
                dialogueSpoken[2] = "I know you just moved in, but... I really appreciate this gesture. Thank you.";
                dialogueSpoken[3] = "END";
                break;
            case 12:
                dialogueSpoken[0] = "MUAHAHAHA! YOU DARE TO CHALLENGE ME?";
                dialogueSpoken[1] = "You aren't here for a challenge? You are here to make a peace offering?";
                dialogueSpoken[2] = "Although I prefer heated battles between two rivals... this is nice.";
                dialogueSpoken[3] = "We shall face off next time!";
                dialogueSpoken[4] = "END";
                break;
            case 13:
                dialogueSpoken[0] = "Winter is almost over... thank goodness. I hate having to scrape the snow off of my nonexistent car.";
                dialogueSpoken[1] = "Oh, flowers? Well look at that, spring is already here! Thanks.";
                dialogueSpoken[2] = "END";
                break;
            case 14:
                dialogueSpoken[0] = "Flowers? Oh, thank you so much!";
                dialogueSpoken[1] = "This is perfect... this time of season is always so dreary and miserable.";
                dialogueSpoken[2] = "Flowers make it a little better. It takes one kind gesture to make someone's day, and you've definitely made mine. Thanks again.";
                dialogueSpoken[3] = "END";
                break;
            case 15:
                dialogueSpoken[0] = "I'm so excited for hot weather again! I want to go swimming in the river again with all my friends!";
                dialogueSpoken[1] = "Oh, you're here with flowers? RADICAL! I love flowers! I just don't like the bugs. I've got a grudge against bees. They are evil.";
                dialogueSpoken[2] = "But anyways, thanks for the flowers. I'll be sure to put them in a nice vase!";
                dialogueSpoken[3] = "END";
                break;
        }

        typewriter.enabled = true;
        dialoguetext.text = dialogueSpoken[0];
        currentDialoguePlacement++;
    }
        


    public void closeDialogue(bool isCutscene = true)
    {
        dialoguebox.DOMove(initpos.transform.position, 0.25f, true);
        dialoguebox.DOSizeDelta(new Vector2(25, 15), 0.5f, true);
        dialoguetexttransform.DOSizeDelta(new Vector2(22, 13.5f), 0.5f, true);
        if (isCutscene)
        {
            originalLoc.GetComponent<triggerEvent>().finishUpDoor();
        }
    }
}
