using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragged = false; //Drag en cours

    private Vector3 startPosition;
    private int startIndexLayer;

    private GameObject table;
    private SpriteRenderer myRenderer;
    private bool isOverTable = false;
    private bool isOnTable = false;

    private void Awake()
    {
        myRenderer = GetComponent<SpriteRenderer>();
    }

    public void Start()
    {
        //On retrouve la table
        table = GameObject.Find("Table");
    }

    private void OnMouseDown()
    {
        if (isOnTable) return;//If we are on the table, just don't drag

        startIndexLayer = myRenderer.sortingOrder;
        //Don't mess with anything
        myRenderer.sortingOrder = 100;

        startPosition = transform.position;
        isDragged = true;
    }
    
    public void OnMouseUp()
    {
        if (isOnTable) return;//Bug prevent for card on table

        if (isOverTable)
        {
            isOnTable = true;
            table.GetComponentInChildren<HandsGrid>().addCard(gameObject);//table is now the parent
        }
        else
        {
            transform.position = startPosition;
        }
        myRenderer.sortingOrder = startIndexLayer;
        isDragged = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (isDragged)
        {
            //Mouse position
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            transform.position = pos;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Table")
        {
            isOverTable = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Table")
        {
            isOverTable = false;
        }
    }
}
