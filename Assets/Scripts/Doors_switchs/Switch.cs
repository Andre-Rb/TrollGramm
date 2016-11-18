using System.Linq;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public SecondDoor Door;
    private Renderer rend;
    private Color _baseColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        _baseColor = rend.material.color;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Door.OpenDoor();
        }
    }

    public void GoGreen()
    {
        rend.material.color = Color.green;

    }

    public void ResetColor()
    {
        rend.material.color = _baseColor;
    }
}