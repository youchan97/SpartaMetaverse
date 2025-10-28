using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionType
{
    MiniGame,
    LeaderBoard
}

public interface ITriggerable
{
    public InteractionType Type { get; set; }
    public void Interact(PlayerController player);
}


public class Interaction : MonoBehaviour, ITriggerable
{
    [SerializeField] private InteractionType type;
    public InteractionType Type { get => type; set => type = value; }

    [SerializeField] protected PopupManager popupManager;

    public virtual void Interact(PlayerController player)
    {
        player.StopPlayer();
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetComponent<PlayerController>())
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            Interact(player);
        }
    }
}
