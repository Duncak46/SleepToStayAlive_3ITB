using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public ScriptableObjects scriptableObject;

    int kolikStoji1;
    int kolikStoji2;
    public static string kteraBudova;

    void NastaveniHodnot()
    {
        //Koule
        hodnoty_do_seznamu firstItem = scriptableObject.seznamPolozek[0];
        kolikStoji1 = firstItem.kolik_stoji_gold;

        //Dvojèata
        hodnoty_do_seznamu secondItem = scriptableObject.seznamPolozek[1];
        kolikStoji2 =secondItem.kolik_stoji_gold;
    }

    public TileData TileData;

    public GameObject buildingPrefab;
    private int koliktostoji = 5;
    internal void Build(GameObject prefab)
    {

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
    void Update()
    {
        Debug.Log(kteraBudova);
    }
    public GameObject Dvojcata;
    public GameObject Koule;
    public void SetDvojcata()
    {
        buildingPrefab = Dvojcata;
    }
    public void SetKoule()
    {
        buildingPrefab = Koule;
    }
}
