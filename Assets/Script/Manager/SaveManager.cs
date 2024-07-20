using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    private void Awake()
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

    public void DeleteGame(int slot)
    {
        PlayerPrefs.DeleteKey("Coins_" + slot);
        PlayerPrefs.DeleteKey("Reputation_" + slot);
        PlayerPrefs.DeleteKey("Level_" + slot);
        PlayerPrefs.DeleteKey("Ghost_" + slot);
        PlayerPrefs.DeleteKey("GhostItem_" + slot);
        PlayerPrefs.DeleteKey("RoomsId_" + slot);
        PlayerPrefs.DeleteKey("GhostId_" + slot);
        PlayerPrefs.DeleteKey("Rooms_" + slot);
        PlayerPrefs.DeleteKey("RoomItem_" + slot);
        PlayerPrefs.DeleteKey("Name_" + slot); 
        PlayerPrefs.DeleteKey("Fare_" + slot);
        PlayerPrefs.Save();
    }

    public void LoadGame(int slot, out int coins, out int reputation, out int[][] ghost, out int[][] ghostId, out int level, out int[] ghostItem, out int[][] rooms, out int[][] roomsId, out int[] roomItem, out string name, out int fare)
    {
        coins = PlayerPrefs.GetInt("Coins_" + slot, 0);
        reputation = PlayerPrefs.GetInt("Reputation_" + slot, 0);
        level = PlayerPrefs.GetInt("Level_" + slot, 0);
        name = PlayerPrefs.GetString("Name_" + slot, "");

        ghost = Deserialize2DArray("Ghost_" + slot);
        ghostId = Deserialize2DArray("GhostId_" + slot);
        ghostItem = DeserializeArray<int>("GhostItem_" + slot);
        rooms = Deserialize2DArray("Rooms_" + slot);
        roomsId = Deserialize2DArray("RoomsId_" + slot);
        roomItem = DeserializeArray<int>("RoomItem_" + slot);
        fare = PlayerPrefs.GetInt("Fare_" + slot, 0);
    }

    public void SaveGame(int slot, int coins, int reputation, int[][] ghost, int[][] ghostId, int level, int[] ghostItem, int[][] rooms, int[][] roomsId, int[] roomItem, string name, int fare)
    {
        PlayerPrefs.SetInt("Coins_" + slot, coins);
        PlayerPrefs.SetInt("Reputation_" + slot, reputation);
        PlayerPrefs.SetInt("Level_" + slot, level);
        PlayerPrefs.SetString("Name_" + slot, name);

        PlayerPrefs.SetString("Ghost_" + slot, Serialize2DArray(ghost));
        PlayerPrefs.SetString("GhostId_" + slot, Serialize2DArray(ghostId));
        PlayerPrefs.SetString("GhostItem_" + slot, SerializeArray(ghostItem));
        PlayerPrefs.SetString("Rooms_" + slot, Serialize2DArray(rooms));
        PlayerPrefs.SetString("RoomsId_" + slot, Serialize2DArray(roomsId));
        PlayerPrefs.SetString("RoomItem_" + slot, SerializeArray(roomItem));
        PlayerPrefs.SetInt("Fare_" + slot, fare);

        PlayerPrefs.Save();
    }

    private string SerializeArray<T>(T[] array)
    {
        return JsonUtility.ToJson(new SerializableArray<T>(array));
    }

    private string Serialize2DArray(int[][] array)
    {
        return JsonUtility.ToJson(new Serializable2DArray(array));
    }

    private T[] DeserializeArray<T>(string key)
    {
        string json = PlayerPrefs.GetString(key, "");
        return string.IsNullOrEmpty(json) ? new T[0] : JsonUtility.FromJson<SerializableArray<T>>(json).array;
    }

    private int[][] Deserialize2DArray(string key)
    {
        string json = PlayerPrefs.GetString(key, "");
        if (string.IsNullOrEmpty(json))
            return new int[0][];

        Serializable2DArray array = JsonUtility.FromJson<Serializable2DArray>(json);
        int[][] result = new int[array.rows][];
        for (int i = 0; i < array.rows; i++)
        {
            result[i] = new int[array.cols];
            for (int j = 0; j < array.cols; j++)
            {
                result[i][j] = array.data[i * array.cols + j];
            }
        }
        return result;
    }

    [System.Serializable]
    public class SerializableArray<T>
    {
        public T[] array;

        public SerializableArray(T[] array)
        {
            this.array = array;
        }
    }

    [System.Serializable]
    public class Serializable2DArray
    {
        public int[] data;
        public int rows;
        public int cols;

        public Serializable2DArray(int[][] array)
        {
            rows = array.Length;
            cols = array[0].Length;
            data = new int[rows * cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    data[i * cols + j] = array[i][j];
                }
            }
        }
    }
}
