using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SubtitlesController : MonoBehaviour
{
    public string speaker;
    public Text textComponent;


    public void SetActive(bool b)
    {
        gameObject.SetActive(b);

    }

}
