using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Location currentlocation;
    public List<Item> inventory = new List<Item>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool ChangeLocation(GameController controller, string connectionNoun)
    {
        Connection connection = currentlocation.GetConnection(connectionNoun);
        if (connection != null)
        {
            if (connection.connectionEnabled)
            {
                currentlocation = connection.location;
                return true;
            }
        }
        return false;
    }

    public bool CanUseItem(GameController controller, Item item)
    {
        if (item.targetItem == null)
            return true;

        if (HasItem(item.targetItem))
            return true;

        if (currentlocation.HasItem(item.targetItem))
            return true;

        return false;
    }

    private bool HasItem(Item itemToCheck)
    {
        foreach (Item item in inventory)
        {
            if (item == itemToCheck && item.itemEnabled)
                return true;
        }
        return false;
    }

    public bool CanTaIkToItem(GameController controller, Item item)
    {
        return item.playerCanTalkTo;
    }

    public bool CanGiveToItem(GameController controller, Item item)
    {
        return item.playerCanGiveTo;
    }

    public bool HasItemByName(string noun)
    {
        foreach (Item item in inventory)
        {
            if (item.itemName.ToLower() == noun.ToLower())
                return true;
        }
        return false;
    }
    public void Teleport(GameController controller, Location destination)
    {
        currentlocation = destination;
    }
}
