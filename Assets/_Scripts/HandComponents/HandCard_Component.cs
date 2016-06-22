﻿using UnityEngine;
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
                bool playedCard = PlayCard(tile);
            }
        }	
	}

    //play card, return true if it's played.
    public bool PlayCard(GameObject tileToPlace)
    {
        if (!tileToPlace.GetComponent<Tile_Component>().active)
            return false;

        //check cost of card to play.
        if(GetComponentInParent<ResourceManager>().CanPlay(GetComponent<CardDictionary>().cardNumsToName[cardID].GetComponent<BaseUnit_Component>().cost))
        {
            //spend resources then summon card.
            GetComponentInParent<ResourceManager>().SpendResources(GetComponent<CardDictionary>().cardNumsToName[cardID].GetComponent<BaseUnit_Component>().cost);
            Transform card = gameObject.GetComponent<CardDictionary>().cardNumsToName[cardID].GetComponent<BaseUnit_Component>().Summon(tileToPlace.GetComponent<RectTransform>());

            tileToPlace.GetComponent<Tile_Component>().active = false;
            canPlay = false;

            played = true;
            return true;
        }
        return false;
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