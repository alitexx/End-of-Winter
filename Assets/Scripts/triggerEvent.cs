using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerEvent : MonoBehaviour
{
    [SerializeField] private int knocksNeeded;
    [SerializeField] private GameObject spaceBarIcon;
    [SerializeField] private AudioSource knock;
    [SerializeField] private dialogue dialoguemanagement;
    [SerializeField] private pauseMenu pauseScript;
    public playerController player;
    [SerializeField] private Animator door;
    private int knocksDone;
    public bool knockRange;
    private bool doorComplete;

    private void Update()
    {
        if(knockRange && Input.GetKeyDown(KeyCode.Space) && !doorComplete && !pauseScript.pauseOpen)
        {
            Debug.Log("PRESSED!!");
            knock.Play();
            knocksDone++;
            if (knocksDone >= knocksNeeded)
            {
                doorComplete = true;
                //open door
                door.enabled = true;
                spaceBarIcon.SetActive(false);
                player.isfrozen = true;
                dialoguemanagement.runDialogue();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "Door")
        {

            //show space bar icon
            spaceBarIcon.SetActive(true);
            knockRange = true;
        }
    }
}
