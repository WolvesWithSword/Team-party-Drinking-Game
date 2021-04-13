using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCard : MonoBehaviour
{

    public void onHoverCard()
    {
        gameObject.transform.localScale = Vector3.Scale(gameObject.transform.localScale,new Vector3(2, 2, 2));// X2
        gameObject.layer = LayerMask.NameToLayer("ZoomCard");
    }

    public void onHoverCardLeft()
    {
        gameObject.transform.localScale = Vector3.Scale(gameObject.transform.localScale, new Vector3(0.5f, 0.5f, 0.5f));// /2
        gameObject.layer = LayerMask.NameToLayer("Card");
    }
}
