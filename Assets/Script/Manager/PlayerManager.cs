using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int Coins;
    public int Reputation;
    public int Level;
    public int Fare;
    public int[][] Ghost;
    public int[][] GhostId;
    public int[] GhostItem;
    public int[][] Rooms;
    public int[][] RoomsId;
    public int[] RoomItem;
    public string Name;
    public static PlayerManager Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStats(int coins, int reputation, int level, int fare, int[][] ghost, int[][] ghostId, int[] ghostItem, int[][] rooms, int[][] roomsId, int[] roomItem, string name)
    {
        Coins = coins;
        Reputation = reputation;
        Level = level;
        Fare = fare;
        Ghost = ghost;
        GhostId = ghostId;
        GhostItem = ghostItem;
        Rooms = rooms;
        RoomsId = roomsId;
        RoomItem = roomItem;
        Name = name;
    }
    
}
