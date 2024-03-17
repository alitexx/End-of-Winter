using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkOutOfRange : MonoBehaviour
{
    [SerializeField] private GameObject spaceBarIcon;
    [SerializeField] private triggerEvent doorScript;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //remove space bar icon
            spaceBarIcon.SetActive(false);
            doorScript.knockRange = false;
        }
    }
}
