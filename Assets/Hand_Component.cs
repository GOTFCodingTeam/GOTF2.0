using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hand_Component : MonoBehaviour
{
    ArrayList cards;
	// Use this for initialization
	void Start ()
    {
        cards = new ArrayList();
        cards.Add(0001);
        cards.Add(0000);
	    
        foreach(int card in cards)
        {

        }
	}
	
	// Update is called once per frame
	void Update ()
    {

    }
}
