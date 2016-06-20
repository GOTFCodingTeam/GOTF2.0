using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HandCard_Component : MonoBehaviour {
    public int cardID;
    public Image card;

    GameObject[] placeableTiles;

    public bool canPlay = false;

	// Use this for initialization
	void Start () {

        placeableTiles = GameObject.FindGameObjectsWithTag("side1tile");
	}
	
	// Update is called once per frame
	void Update () {
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
                }
            }
        }
	
	}

    public void OnClick()
    {
        canPlay = true;
        if(canPlay)
        {
            ;
        }
    }
}
