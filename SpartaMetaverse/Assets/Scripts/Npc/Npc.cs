using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Npc : MonoBehaviour
{
    [SerializeField] NpcType npcType;

    [SerializeField] string[] textData;
    [SerializeField] string EventText;

    [SerializeField] PopupManager popupManager;

    public void Talk()
    {
        //
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<PlayerController>())
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.StopPlayer();
            Talk();
        }
    }
}
