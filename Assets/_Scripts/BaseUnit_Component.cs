using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BaseUnit_Component : MonoBehaviour
{

    public int maxHealth;
    public int health;

    public int baseAttack;
    public int attack;

    public int baseCountdown;
    public int countdown;

    //ability effects.
    public Transform effects;


	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //summons a creature
    public void Summon(RectTransform tile)
    {
        Transform thisGuy = Instantiate<Transform>(this.transform);
        tile.GetComponent<Tile_Component>().unit = thisGuy.GetComponent<RectTransform>();
        thisGuy.transform.SetParent(tile, false);

        health = maxHealth;
        attack = baseAttack;
        countdown = baseCountdown;
    }

    
    //move unit from previous tile to the next tile.Actually creates instance with the exact same qualities.
    public void Move(RectTransform previousTile, RectTransform tileTo)
    {
        Transform thisGuy = Instantiate<Transform>(this.transform);

        //set unit components
        tileTo.GetComponent<Tile_Component>().unit = thisGuy.GetComponent<RectTransform>();
        previousTile.GetComponent<Tile_Component>().unit = null;


        thisGuy.transform.SetParent(tileTo, false);

        DestroyImmediate(gameObject, true);

    }
}
