using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(menuName = "Action/Say")]
public class Say : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (SayToItem(controller, controller.player.currentlocation.items, noun))
            return;
        controller.currentText.text = "Nothing Responds!!";
    }

    private bool SayToItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemEnabled)
                if (controller.player.CanTaIkToItem(controller, item))
                {
                    if (item.InteractWith(controller, "say", noun))
                        return true;

                }
        }
        return false;
    }
}
