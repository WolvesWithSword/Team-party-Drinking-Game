using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragged = false; //deplacer
    private GameObject canvas;
    private GameObject startZone;
    private Vector3 startPosition;

    private GameObject table;
    private bool isOverTable = false;
    private bool isOnTable = false;

    public void Start()
    {
        canvas = GameObject.Find("Canvas");
        table = GameObject.Find("Table");
    }

    public void onSelect()
    {
        if (isOnTable) return;//If we are on the table, just don't drag

        startZone = transform.parent.gameObject;
        startPosition = transform.position;
        isDragged = true;    
    } 


    public void onDrop()
    {
        if (isOnTable) return;//Bug prevent for card on table

        if (isOverTable)
        {
            transform.SetParent(table.transform, false); //set le parent de l'objet( zone de depart)
            isOnTable = true;
        }
        else
        {
            transform.SetParent(startZone.transform, false); //set le parent de l'objet( zone de depart)
            transform.position = startPosition;
        }
        isDragged = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (isDragged)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(canvas.transform, false);
            
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverTable = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverTable = false;
    }
}
