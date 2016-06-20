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

    //summons a creature
    public Transform Summon(RectTransform tile)
    {
        Transform thisGuy = Instantiate(transform);
        tile.GetComponent<Tile_Component>().unit = thisGuy.GetComponent<RectTransform>();
        thisGuy.transform.SetParent(tile, false);

        health = maxHealth;
        attack = baseAttack;
        countdown = baseCountdown;
        return transform;
    }

    
    //move unit from previous tile to the next tile.Actually creates instance with the exact same qualities.
    public void Move(RectTransform previousTile, RectTransform tileTo)
    {
        Transform thisGuy = Instantiate(transform);

        //set unit components
        tileTo.GetComponent<Tile_Component>().unit = thisGuy.GetComponent<RectTransform>();
        previousTile.GetComponent<Tile_Component>().unit = null;


        thisGuy.transform.SetParent(tileTo, false);

        DestroyImmediate(gameObject, true);
    }
}
