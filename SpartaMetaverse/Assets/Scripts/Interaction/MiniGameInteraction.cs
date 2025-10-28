using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameInteraction : Interaction
{

    public override void Interact(PlayerController player)
    {
        base.Interact(player);
        popupManager.IsMiniGamePopupOpen(true);
    }
}
