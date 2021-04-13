using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject Card;
    public GameObject Zone;
    public int NumberOfCardDrawned;

    public void OnClick()
    {
        for(int i = 0; i < NumberOfCardDrawned; i++)
        {
            GameObject playerCard = Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.transform.SetParent(Zone.transform, false);
        }
    }
}
