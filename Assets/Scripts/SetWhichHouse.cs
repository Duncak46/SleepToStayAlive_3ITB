using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetWhichHouse : MonoBehaviour
{

    public TextMeshProUGUI textMeshPro; // Pøetáhnìte komponentu TextMeshPro sem
    public void NastavHouse()
    {
        if (textMeshPro != null)
        {
            string text = textMeshPro.text; // Získání obsahu textu
            Tile.kteraBudova = text;
        }
        else
        {
            Debug.LogWarning("TextMeshPro component is not assigned.");
        }
    }
}
//NEFUNGUJE
