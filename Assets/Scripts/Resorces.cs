using UnityEngine;
using System;

public sealed class Resorces : MonoBehaviour
{
    private static Resorces _instance;
    public static Resorces Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Resorces>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<Resorces>();
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return _instance;
        }
    }

    public static int gold;
    public static int stone;
    public static int numBuildings;

    // Interval pro aktualizaci zdrojù (v sekundách)
    private float updateInterval = 5f;
    private float timeSinceLastUpdate = 0f;

    private void Start()
    {
        InitResources();
    }

    private void Update()
    {
        // Pøièítá zdroje v daném intervalu
        timeSinceLastUpdate += Time.deltaTime;
        if (timeSinceLastUpdate >= updateInterval)
        {
            timeSinceLastUpdate = 0f;
            UpdateResources();
        }
    }

    private void InitResources()
    {
        gold = 20;
        stone = 10;
        numBuildings = 0;
    }

    public void AddStone()
    {
        stone++;
    }

    public static bool SpendGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool SpendStone(int amount)
    {
        if (stone >= amount)
        {
            stone -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdateResources()
    {
        // Pøièítá zdroje na základì poètu budov
        gold += numBuildings * 4;
        DisplayResources();
    }

    public void DisplayResources()
    {
        Debug.Log("Gold: " + gold);
        Debug.Log("Stone: " + stone);
    }
}
