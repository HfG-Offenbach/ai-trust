using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Textfield;

    public void SetText(string text)
    {
        Textfield.text = text;
    }
}
