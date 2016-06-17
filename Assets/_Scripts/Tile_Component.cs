using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tile_Component : MonoBehaviour
{
    //adjacent tiles
    public RectTransform[] adjacents;

    //unit object
    public RectTransform unit;

    //the first clicked tile is the active tile.
    public bool active = false;

    //displayed image. This will probably change later so that you can se something that isn't the card. Works for now, I guess.
    public Image picture;

    //when button component of image is clicked.
    public void OnClick()
    {
        //if you click on yourself, it's not active.
        if (active == true)
        {
            active = false;
            return;
        }

        //find adjacent active spaces to move to, set active to false in spaces.
        foreach (RectTransform adjacent in adjacents)
        {
            if(adjacent.GetComponent<Tile_Component>().active == true)
            {
                //move unit
                adjacent.GetComponent<Tile_Component>().unit.GetComponent<BaseUnit_Component>().Move(adjacent.GetComponent<RectTransform>(), GetComponent<RectTransform>());           

                adjacent.GetComponent<Tile_Component>().active = false;

                //set image if there's a unit.
                if (unit != null)
                {
                    picture = unit.GetComponent<Image>();
                }
                return;
            }
        }
        
        active = true;
    }
}
