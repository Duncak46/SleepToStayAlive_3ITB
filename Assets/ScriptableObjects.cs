using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Budova", menuName = "MojeNastaveni/NovyObjekt", order = 1)]
public class ScriptableObjects : ScriptableObject
{
    public List<hodnoty_do_seznamu> seznamPolozek = new List<hodnoty_do_seznamu>();
}

[System.Serializable]
public class hodnoty_do_seznamu
{
    public string nazev;
    public int kolik_stoji_gold;
    public int kolik_stoji_stone;
    public TypObjektu typ;
}
public enum TypObjektu
{
    Kulata,
    Hranata
}

