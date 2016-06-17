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
        countdown = baseCountdown;
        attack = baseAttack;
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //move unit from previous tile to the next tile.
    public void Move(RectTransform previousTile, RectTransform tileTo)
    {
        //set unit components
        tileTo.GetComponent<Tile_Component>().unit = GetComponent<RectTransform>();
        previousTile.GetComponent<Tile_Component>().unit = null;

        //set sprite components
        previousTile.GetComponent<Image>().sprite = null;
        tileTo.GetComponent<Image>().sprite = GetComponent<Image>().sprite;

    }
}
