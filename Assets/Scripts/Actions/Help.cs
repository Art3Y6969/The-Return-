using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Action/Help")]
public class Help : Action
{

    public override void RespondToInput(GameController controller, string noun)
    {
        controller.currentText.text = "Type a Verb followed by a noun(e.r. \"go north\")";
        controller.currentText.text += "\nAllowed verbs:\nGo, examine, get, use, give, inventory, talkto, say, help";
    }
}
