using UnityEngine;
using UnityEngine.UI;

public class SubtitlesController : MonoBehaviour
{
    public Text speaker;
    public Text textComponent;


    public void SetActive(bool b)
    {
        gameObject.SetActive(b);

    }

}
