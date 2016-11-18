using UnityEngine;
using System.Collections;

public class LastRoomSwitch : MonoBehaviour
{
    Renderer _renderer;
    private Color _baseColor;

    void Start()
    {

        _renderer = GetComponent<Renderer>();

        _baseColor = _renderer.material.color;

    }



    public void TurnGreen()
    {
        _renderer.material.color = Color.green;
    }

    public void ResetColor()
    {
        _renderer.material.color = _baseColor;

    }


    void Activate()
    {
        TurnGreen();

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.Player.ToString()))
        {

            Activate();
        }
    }
}



