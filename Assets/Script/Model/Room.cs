using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room 
{
    // Start is called before the first frame update
    private static int nextId = 1;

    public int Id { get; set; }
    public string Type { get; set; }
    public int Level { get; set; }
    public int GhostCapacity { get; set; }
    public int[] RoomId { get; set; }
    public int ItemId { get; set; }

    public bool IsPlaced { get; set; }
    public Room(string type = "Hautend", int level = 0, int ghostCapacity = 0)
    {
        Id = nextId++;
        Type = type;
        Level = level;
        GhostCapacity = ghostCapacity;
        RoomId = new int[] { 0, 0 };
        ItemId = 0;
        IsPlaced = false;
    }


    public void Upgrade()
    {
        Level++;
        // GhostCapacity += 2; 
    }

    public void Place(int[] roomId)
    {
        RoomId = roomId;
        IsPlaced = true;
    }
}
