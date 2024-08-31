using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Action/Get")]
public class Get : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        foreach (Item item in controller.player.currentlocation.items)
        {
            if (item.itemEnabled && item.itemName == noun)
            {
                if (item.playerCanTake)
                {
                    controller.player.inventory.Add(item);
                    controller.player.currentlocation.items.Remove(item);
                    controller.currentText.text = "You take the " + noun;
                }
            }
        }
        controller.currentText.text = "You can't get that ";
    }
}
