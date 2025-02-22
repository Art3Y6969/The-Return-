using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Action/TalkTo")]
public class TalkTo : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (TalkToItem(controller, controller.player.currentlocation.items, noun))
            return;
        controller.currentText.text = "There is no " + noun + " here!";
    }
    private bool TalkToItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun && item.itemEnabled)
            {
                if (controller.player.CanTaIkToItem(controller, item))
                {
                    if (item.InteractWith(controller, "talkto"))
                        return true;
                }
                controller.currentText.text = "The " + noun + " doesn't respond";
                return true;
            }
        }
        return false;
        
    }
}
