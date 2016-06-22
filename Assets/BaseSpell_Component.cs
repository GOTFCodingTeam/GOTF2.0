using UnityEngine;
using System.Collections;
using System;

public class BaseSpell_Component : BaseCard {

    //summon activates whenever a card is played. All spells (at least for now) target a specific tile.
    public override Transform Summon(RectTransform location, Transform hand)
    {
        if (location.GetComponent<Tile_Component>().unit != null)
            location.GetComponentInChildren<BaseUnit_Component>().TakeDamage(5);
        else
        {
            hand.GetComponent<ResourceManager>().AddResources(cost);
            hand.GetComponent<Hand_Component>().AddCard(0003);
        }
        return transform;
    }
}
