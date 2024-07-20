using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost
{
    private static int nextId = 1; 

    // Properties
    public int Id { get; private set; }
    public string Name { get; set; }
    public string Trait { get; set; }
    public bool IsPlaced { get; set; }
    public int[] RoomId { get; set; }
    public int ItemId { get; set; }

    // Constructor
    public Ghost(string name, string trait, int[] roomId = null)
    {
        Id = nextId++; 
        Name = name;
        Trait = trait;
        IsPlaced = false;
        RoomId = roomId ?? new int[] { 0, 0 };
        ItemId = 0;
    }

    public void Place(int[] roomId)
    {
        RoomId = roomId;
        IsPlaced = true;
    }
}
