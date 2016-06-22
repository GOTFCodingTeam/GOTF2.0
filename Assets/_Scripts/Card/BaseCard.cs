using UnityEngine;
using System.Collections;

abstract public class BaseCard : MonoBehaviour {
    public string cost;

    abstract public Transform Summon(RectTransform location, Transform hand);
}
