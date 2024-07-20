using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainMenu;
    void Start()
    {
        MainMenu();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        mainMenu.SetActive(false);
    }

public void StartNewGame(int slot, string name)
{
    SaveManager.Instance.DeleteGame(slot);
    
    int coins = 0;
    int reputation = 0;
    int level = 1;
    int fare = 25;
    
    int[][] ghost = new int[][]
    {
        new int[] { 0, 0 },
    };
    
    int[] ghostItem = new int[0]; 
    
    int[][] rooms = new int[][]
    {
        new int[] { 0, 1 },
        new int[] { 0, -1 }
    };
    int[][] ghostId = new int[][]
    {
        new int[] { 0, 0 },
    };
    int[][] roomsId = new int[][]
    {
        new int[] { 0, 0 },
    };
    
    int[] roomItem = new int[0]; 
    
    SaveManager.Instance.SaveGame(slot, coins, reputation, ghost, ghostId,level, ghostItem, rooms,roomsId, roomItem, name, fare);
    GameSceneManager.Instance.LoadNextScene();
}


    public void ContinueGame(int slot)
    {
        int coins, reputation, level, fare;
        string name;
        int[][] ghost, rooms, ghostId, roomsId;
        int[] ghostItem, roomItem;
        SaveManager.Instance.LoadGame(slot, out coins, out reputation, out ghost, out ghostId,out level, out ghostItem, out rooms,out roomsId, out roomItem, out name, out fare);
        PlayerManager.Instance.SetStats(coins, reputation, level, fare, ghost, ghostId, ghostItem, rooms, roomsId, roomItem, name);
        GameSceneManager.Instance.LoadNextScene();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
