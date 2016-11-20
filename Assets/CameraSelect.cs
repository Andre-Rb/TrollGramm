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
        FPSCamera.gameObject.SetActive(false);
        TPSCamera.gameObject.SetActive(false);

        if (chooseFPS)
        {
            _playerManetteClavier.PlayerCamera = FPSCamera;
            FPSCamera.gameObject.SetActive(true);

        } else if (chooseTPS)
        {
            _playerManetteClavier.PlayerCamera = TPSCamera;
            TPSCamera.gameObject.SetActive(true);


        }
        else
        {
            throw new UnityException("You have to choose a camerafor the player");
        }
    }

}
