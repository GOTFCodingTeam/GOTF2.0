using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HandCard_Component : MonoBehaviour {
    public int cardID;
    public Image card;

    GameObject[] placeableTiles;

    public bool canPlay = false;
    public bool played = false;

	// Get all possible tiles.
	void Start () {
        placeableTiles = GameObject.FindGameObjectsWithTag("side1tile");
	}
	
	// Updates card's image if it's drawn, and gives it the option to be played.
	void Update () {
        GetComponent<Image>().sprite = GetComponent<CardDictionary>().cardNumsToName[cardID].GetComponent<Image>().sprite;
        if(canPlay)
        {
            foreach(GameObject tile in placeableTiles)
            {
                if(tile.GetComponent<Tile_Component>().active)
                {

                    Transform card = gameObject.GetComponent<CardDictionary>().cardNumsToName[cardID].GetComponent<BaseUnit_Component>().Summon(tile.GetComponent<RectTransform>());

                    tile.GetComponent<Tile_Component>().active = false;
                    canPlay = false;

                    played = true;
                }
            }
        }
	
	}

    //first click to set up movement.
    public void OnClick()
    {
        if(canPlay)
        {
            canPlay = false;
            return;
        }

        canPlay = true;
        foreach (GameObject tile in placeableTiles)
        {
            if (tile.GetComponent<Tile_Component>().active)
            {
                tile.GetComponent<Tile_Component>().active = false;//so card isn't placed on already active squares.
            }
        }
    }
}
