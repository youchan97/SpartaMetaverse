using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearderBoardInteraction : Interaction
{
    public override void Interact(PlayerController player)
    {
        base.Interact(player);
        popupManager.IsLeaderBoardPopupOpen(true);
    }
}
