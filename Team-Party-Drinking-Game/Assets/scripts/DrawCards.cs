using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject Card;
    public GameObject Zone;

    void Start()
    {
        Debug.Log("Started");
    }

    public void OnClick()
    {
        Debug.Log("Clicked");
        for(int i = 0; i < 1; i++)
        {
            GameObject playerCard = Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.transform.SetParent(Zone.transform, false);
        }
    }
}
