using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HandCard_Component : MonoBehaviour {
    public int cardID;
    public Image card;

    GameObject[] placeableTiles;

    public bool canPlay = false;
    public bool played = false;

	// Use this for initialization
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
                    GameObject card = Instantiate(gameObject.GetComponent<CardDictionary>().cardNumsToName[cardID]);
                    card.transform.SetParent(tile.transform, false);
                    tile.GetComponent<Tile_Component>().unit = card.GetComponent<RectTransform>();
                    tile.GetComponent<Tile_Component>().active = false;
                    canPlay = false;

                    played = true;
                }
            }
        }
	
	}

    public void OnClick()
    {
        canPlay = true;
        foreach (GameObject tile in placeableTiles)
        {
            if (tile.GetComponent<Tile_Component>().active)
            {
                tile.GetComponent<Tile_Component>().active = false;
            }
        }

    }
}
