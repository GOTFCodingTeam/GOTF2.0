using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardDictionary : MonoBehaviour
{
    public Dictionary<int, GameObject> cardNumsToName = null;
    // add all cards to dictionary.
    void Start ()
    {
         cardNumsToName = new Dictionary<int, GameObject>();
         cardNumsToName.Add(0000, (GameObject)Resources.Load("Prefabs/Units/0000-MountainUnit"));
         cardNumsToName.Add(0001, (GameObject)Resources.Load("Prefabs/Units/0001-AirThing"));
    }
}