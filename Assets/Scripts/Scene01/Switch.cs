using UnityEngine;

public class Switch : MonoBehaviour
{
    private Renderer rend;
    private Color _baseColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        _baseColor = rend.material.color;
    }

   

    protected internal void GoGreen()
    {
        rend.material.color = Color.green;

    }

    protected internal void ResetColor()
    {
        rend.material.color = _baseColor;
    }
}