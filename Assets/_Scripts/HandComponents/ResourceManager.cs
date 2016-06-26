using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;
using System;

public class ResourceManager : MonoBehaviour
{
    public int earth;
    public int vortex;
    public int water;

    public int neutral;

    public int maxEarth;
    public int maxVortex;
    public int maxWater;
    public int maxNeutral;

    public Text earthBox;
    public Text vortexBox;
    public Text waterBox;
    public Text neutralBox;
    
    // Use this for initialization
	void Start () {
        UpdateCounts();
    }
    
    //changes text on displayed resources.
    void UpdateCounts()
    {
        earthBox.text = earth + "/" + maxEarth;
        vortexBox.text = vortex + "/" + maxVortex;
        waterBox.text = water + "/" + maxWater;
        neutralBox.text = neutral + "/" + maxNeutral;
    }

    //check if player can play
    public bool CanPlay(string input)
    {

        for (int x = 0; x < input.Length / 2; x++)
        {
            switch (input.ToCharArray()[x * 2])
            {
                //element type, then get the next character and compare value.
                case 'e':
                    if (int.Parse(input.ToCharArray()[x * 2 + 1].ToString()) <= earth)
                        break;
                    else
                        return false;
                case 'v':
                    if (int.Parse(input.ToCharArray()[x * 2 + 1].ToString()) <= vortex)
                        break;
                    else
                        return false;
                case 'w':
                    if (int.Parse(input.ToCharArray()[x * 2 + 1].ToString()) <= water)
                        break;
                    else
                        return false;
                case 'u':
                    if (int.Parse(input.ToCharArray()[x * 2 + 1].ToString()) <= neutral)
                        break;
                    else
                        return false;
                default:
                    return true;
            }
        }
        return true;
    }

    //spends resources
    public void SpendResources(string input)
    {

        for (int x = 0; x < input.Length / 2; x++)
        {
            switch (input.ToCharArray()[x * 2])
            {
                //element type, then get the next character and compare value.
                case 'e':
                    earth -= int.Parse(input.ToCharArray()[x * 2 + 1].ToString());
                    break;
                case 'v':
                    vortex -= int.Parse(input.ToCharArray()[x * 2 + 1].ToString());
                    break;
                case 'w':
                    water -= int.Parse(input.ToCharArray()[x * 2 + 1].ToString());
                    break;
                case 'u':
                    neutral -= int.Parse(input.ToCharArray()[x * 2 + 1].ToString());
                    break;
            }
        }
        UpdateCounts();
    }

    public void AddResources(string input)
    {

        for (int x = 0; x < input.Length / 2; x++)
        {
            switch (input.ToCharArray()[x * 2])
            {
                //element type, then get the next character and compare value.
                case 'e':
                    earth += int.Parse(input.ToCharArray()[x * 2 + 1].ToString());
                    break;
                case 'v':
                    vortex += int.Parse(input.ToCharArray()[x * 2 + 1].ToString());
                    break;
                case 'w':
                    water += int.Parse(input.ToCharArray()[x * 2 + 1].ToString());
                    break;
                case 'u':
                    neutral += int.Parse(input.ToCharArray()[x * 2 + 1].ToString());
                    break;
            }
        }
        UpdateCounts();
    }
}
