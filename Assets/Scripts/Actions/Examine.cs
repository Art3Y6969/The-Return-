using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Action/Examine")]
public class Examine : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        //items in the room
        if (CheckItems(controller, controller.player.currentlocation.items, noun))
            return;


        //item in the inventory
        if (CheckItems(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "You can't see a " + noun;
    }
    private bool CheckItems(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                if (item.InteractWith(controller, "examine"))
                    return true;
                else
                    controller.currentText.text = "You see " + item.description;
                return true;
            }
        }
        return false;
    }
}
