using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerEvent : MonoBehaviour
{
    [SerializeField] private int knocksNeeded;
    private GameObject door;
    private int knocksDone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Door")
        {

            //show space bar icon

            //when button space is pressed, play door knocking sfx.
            if (Input.GetKeyDown(KeyCode.Space))
            {
                knocksDone++;
                if (knocksDone >= knocksNeeded)
                {
                    //open door
                }
            }
        }
    }
}
