using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Column_Component : NetworkBehaviour
{
    //all tiles in one column
    public RectTransform[] tiles;

    public int startHealth;
    public int remainingHealth;

    // Use this for initialization
    void Start ()
    {
        remainingHealth = startHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
