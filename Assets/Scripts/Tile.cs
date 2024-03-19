using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileData TileData;

    public GameObject buildingPrefab;

    internal void Build(GameObject prefab)
    {
        // Vytvo�� prefab na pozici st�edu pol��ka
        Vector3 centerPosition = transform.position + new Vector3(1f, 0.2f, 1f);
        var bld = Instantiate(prefab, centerPosition, Quaternion.identity, transform);
        TileData.isOccupied = true;
    }

    private void OnMouseDown()
    {
        CommandQueue.Instance.EnqueueCommand(new BuildCommand() { 
            prefab = buildingPrefab, 
            tile = this
        });
    }
}
