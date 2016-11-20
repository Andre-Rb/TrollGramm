using UnityEngine;
using System.Collections;

public class CameraSelect : MonoBehaviour
{

    public Camera FPSCamera;
    public Camera TPSCamera;

    private Player_Manette_Clavier _playerManetteClavier;

    public bool chooseFPS;
    public bool chooseTPS;

    void Start()
    {

        _playerManetteClavier = GetComponent<Player_Manette_Clavier>();

        if (chooseFPS)
        {
            _playerManetteClavier.PlayerCamera = FPSCamera;

        }
    }

}
