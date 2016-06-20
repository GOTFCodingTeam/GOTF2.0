using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hand_Component : MonoBehaviour
{
    ArrayList cards;
    ArrayList buttons;

    public GameObject cardButton;

	// Use this for initialization
	void Start ()
    {
        cards = new ArrayList();
        buttons = new ArrayList();
        cards.Add(0001);
        cards.Add(0000);

        int x = 0;
        foreach(int card in cards)
        {
            //GetComponent<CardDictionary>().cardNumsToName[card]
            GameObject handSlot = Instantiate(cardButton);
            handSlot.GetComponent<HandCard_Component>().cardID = card;
            handSlot.transform.SetParent(transform);
            handSlot.GetComponent<RectTransform>().position = new Vector3(125 * x + 50, 50, 0);
            buttons.Add(handSlot);

            x++;

        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        int x = 0;
        foreach(GameObject slot in buttons)
        {
            if(slot.GetComponent<HandCard_Component>().played)
            {
                slot.GetComponent<HandCard_Component>().played = false;
                cards.Remove(buttons.IndexOf(slot));

                buttons.Remove(slot);
                Destroy(slot);

                break;
            }
            x++;
        }

    }
}
