using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class Hand_Component : NetworkBehaviour
{
    ArrayList cards;
    ArrayList buttons;

    public GameObject cardButton;

	// Fill hand. This would happen at the start of the game.
	void Start ()
    {
        cards = new ArrayList();
        buttons = new ArrayList();
        AddCard(0000);
        AddCard(0001);
        AddCard(0003);
    }

    //adds card with specific id to player's hand.
    public void AddCard(int card)
    {
        if (!localPlayerAuthority)
            return;
        cards.Add(card);

        GameObject handSlot = Instantiate(cardButton);
        handSlot.GetComponent<HandCard_Component>().cardID = card;
        handSlot.transform.SetParent(transform);
        handSlot.GetComponent<RectTransform>().position = new Vector3(125 * buttons.Count + 50, 50, 0);
        buttons.Add(handSlot);
    }

    // Remove all cards that are played.
    void Update ()
    {
        if (!localPlayerAuthority)
            return;
        foreach (GameObject slot in buttons)
        {
            if(slot.GetComponent<HandCard_Component>().played)
            {
                slot.GetComponent<HandCard_Component>().played = false;
                cards.Remove(buttons.IndexOf(slot));

                buttons.Remove(slot);
                Destroy(slot);

                break;
            }
        }
    }
}
