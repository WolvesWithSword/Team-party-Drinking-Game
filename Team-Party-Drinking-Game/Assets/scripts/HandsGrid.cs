using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsGrid : MonoBehaviour
{
    List<GameObject> cards = new List<GameObject>();
    public float offset;
    
    public void addCard(GameObject card)
    {
        card.transform.SetParent(transform);

        cards.Add(card);
        int position = cards.Count;

        SpriteRenderer renderer = card.GetComponent<SpriteRenderer>();
        renderer.sortingOrder = position;

        Collider2D collider = card.GetComponent<Collider2D>();
        Vector3 offsetCard = Vector3.right * collider.bounds.size.x * offset;

        card.transform.localPosition = Vector3.zero;
        card.transform.position += offsetCard * position + (collider.bounds.size.x * Vector3.left)/2;
        //On re-centre la main
        transform.position -= offsetCard / 2;

    }
}
