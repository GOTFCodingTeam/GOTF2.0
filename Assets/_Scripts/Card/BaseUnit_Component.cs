using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BaseUnit_Component : BaseCard
{
    //for cost: resource letter, value, resource letter, value
    //e = earth
    //v = void/vortex
    //w = water
    //u = uncolored.

    public int maxHealth;
    public int health;

    public int baseAttack;
    public int attack;

    public int baseCountdown;
    public int countdown;

    public Text countdownText;
    public Text attackText;
    public Text healthText;

    //ability effects.
    public Transform effects;

    //summons a creature
    public override Transform Summon(RectTransform tile, Transform hand)
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

    void Update()
    {
        healthText.text = "" + health;
        countdownText.text = "" + countdown;
        attackText.text = "" + attack;
    }

    public void TakeDamage( int damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
