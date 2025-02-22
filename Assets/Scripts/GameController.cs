using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class GameController : MonoBehaviour
{
    public Player player;

    public TMP_InputField textEntryField;

    public TMP_Text logText;
    public TMP_Text currentText;

    public Action[] actions;

    [TextArea]
    public string introText;

    // Start is called before the first frame update
    void Start()
    {
        logText.text = introText;
        DisplayLocation();
        textEntryField.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DisplayLocation(bool additive = false)
    {
        string description = player.currentlocation.description + "\n";
        description += player.currentlocation.GetConnectionsText();
        description += player.currentlocation.GetItemsText();
        if (additive)
            currentText.text = currentText.text + "\n" + description;
        else
            currentText.text = description;

    }
    public void TextEntered()
    {
        LogCurrentText();
        ProcessInput(textEntryField.text);

        textEntryField.text = "";
        textEntryField.ActivateInputField();
    }
    void LogCurrentText()
    {
        logText.text += "\n\n";
        logText.text += currentText.text;

        logText.text += "\n\n";
        logText.text += "<color=#aaccaaff>" + textEntryField.text + "</color>";


    }
    void ProcessInput(string input)
    {
        input = input.ToLower();

        char[] delimiter = { ' ' };
        string[] seperateWords = input.Split(delimiter);

        foreach (Action action in actions)
        {
            if (action.keyword.ToLower() == seperateWords[0])
            {
                if (seperateWords.Length > 1)
                {
                    action.RespondToInput(this, seperateWords[1]);
                }
                else
                {
                    action.RespondToInput(this, "");
                }
                return;
            }
        }

        currentText.text = "Nothing happned ! haveing trouble type Help!";
    }
}
