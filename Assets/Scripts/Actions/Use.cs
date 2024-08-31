using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Action/Use")]
public class Use : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        //items in the room
        if (UseItems(controller, controller.player.currentlocation.items, noun))
            return;


        //item in the inventory
        if (UseItems(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "There is no " + noun;
    }
    private bool UseItems(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                if (controller.player.CanUseItem(controller, item))
                {
                    if (item.InteractWith(controller, "use"))
                        return true;
                }
                controller.currentText.text = "The  " + noun + " does nothing";
                return true;
            }
        }
        return false;

    }
}
