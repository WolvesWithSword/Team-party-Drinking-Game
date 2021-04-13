using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    public string Title;
    public string Description;

    // Start is called before the first frame update
    void Start()
    {
        Text[] curTitle = gameObject.GetComponentsInChildren<Text>();

        foreach(Text txt in curTitle)
        {
            if (txt.name.Equals("Title"))
            {
                txt.text = Title;
            }
            else if (txt.name.Equals("Description"))
            {
                txt.text = Description;
            }
            else
            {
                Debug.LogError("Non Managed Field");
            }
        }
    }
}
