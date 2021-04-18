using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject Card;
    public GameObject Zone;
    private HandsGrid grid;

    public int NumberOfCardDrawned;

    private void Start()
    {
        grid = Zone.GetComponent<HandsGrid>();
    }

    void OnMouseDown()
    {
        Debug.Log("Sprite Clicked");
        for (int i = 0; i < NumberOfCardDrawned; i++)
        {
            GameObject playerCard = Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);
            grid.addCard(playerCard);
        }
    }
}
