using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZoomCard : MonoBehaviour
{
    private GameObject firstPlane;
    private GameObject parentZone;
    private int index;

    private GameObject substitute;//Fake object in list
    private bool isBeingDrag = false;

    private void Start()
    {
        firstPlane = GameObject.Find("FirstPlane");
    }

    public void onHoverCard()
    {
        if (!isBeingDrag)
        {
            gameObject.transform.localScale = Vector3.Scale(gameObject.transform.localScale, new Vector3(2, 2, 2));// X2
            gameObject.layer = LayerMask.NameToLayer("ZoomCard");

            substitute = new GameObject("substitute", typeof(RectTransform));

            parentZone = transform.parent.gameObject;//remember my parent
            index = transform.GetSiblingIndex();//remember my position

            //Made substitute fill the empty space
            substitute.transform.SetParent(parentZone.transform, false);
            substitute.transform.SetSiblingIndex(index);

            gameObject.transform.SetParent(firstPlane.transform, true);
            //Move a little bit upper
            transform.position = new Vector3(transform.position.x, transform.position.y + 80, transform.position.z);
        }
    }

    public void onHoverCardLeft()
    {
        if (!isBeingDrag && parentZone != null)
        {
            gameObject.transform.localScale = Vector3.Scale(gameObject.transform.localScale, new Vector3(0.5f, 0.5f, 0.5f));// /2
            gameObject.layer = LayerMask.NameToLayer("Card");

            GameObject.Destroy(substitute);

            //Set last parent and position
            gameObject.transform.SetParent(parentZone.transform, false);
            transform.SetSiblingIndex(index);
            transform.position = new Vector3(transform.position.x, transform.position.y - 80, transform.position.z);
        }
    }

    public void onDragingBegin()
    {
        onHoverCardLeft();
        isBeingDrag = true;
        parentZone = null;
    }
    
    public void onDragingEnding()
    {
        isBeingDrag = false;
    }
}
