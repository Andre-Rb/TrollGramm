using UnityEngine;
using System.Collections;

public class Dialogue
{

    string lineText;
    AudioClip lineclip;

    public string LineText
    {
        get
        {
            return lineText;
        }

        set
        {
            lineText = value;
        }
    }

    public AudioClip Lineclip
    {
        get
        {
            return lineclip;
        }

        set
        {
            lineclip = value;
        }
    }



}
