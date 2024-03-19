using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    int kolikstoji = 5;
    public TileData TileData;

    public GameObject buildingPrefab;
    private int koliktostoji = 5;
    internal void Build(GameObject prefab)
    {
        // Vytvoøí prefab na pozici støedu políèka
        Vector3 centerPosition = transform.position + new Vector3(1f, 0.2f, 1f);
        var bld = Instantiate(prefab, centerPosition, Quaternion.identity, transform);
        TileData.isOccupied = true;
    }

    private void OnMouseDown()
    {

        if (Resorces.SpendGold(koliktostoji * 2))
        {
            if (Resorces.SpendStone(koliktostoji))
            {
                koliktostoji += 3;
                Resorces.numBuildings++;
                CommandQueue.Instance.EnqueueCommand(new BuildCommand()
                {
                    prefab = buildingPrefab,
                    tile = this
                });
                Debug.Log(koliktostoji);
                Debug.Log(Resorces.gold);
                Debug.Log(Resorces.stone);
            }
            else
            {
                Resorces.gold += koliktostoji * 2;
            }
        }
    }
}
