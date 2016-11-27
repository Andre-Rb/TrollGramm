using UnityEngine;

// ReSharper disable once CheckNamespace
public class CameraSelect : MonoBehaviour
{
    public Camera FPSCamera;
    public Camera TPSCamera;
    public Camera Camera2D;

    public PlayerControllerBase PlayerControllerBase;

    public bool ChooseFPS;
    public bool ChooseTPS;
    public bool Choose2D;

    //public Canvas Canvas;

    // ReSharper disable once UnusedMember.Local
    void Awake()
    {
        if (FPSCamera != null)
            FPSCamera.gameObject.SetActive(false);
        if (TPSCamera != null)
            TPSCamera.gameObject.SetActive(false);
        if (Camera2D != null)
            Camera2D.gameObject.SetActive(false);

        if (ChooseFPS)
        {
            PlayerControllerBase.SetCamera(FPSCamera);
            if (FPSCamera != null) FPSCamera.gameObject.SetActive(true);
            else
                throw new UnityException("You have to assign a FPSCamera");
            //Canvas.worldCamera = FPSCamera;
        }
        else if (ChooseTPS)
        {
            PlayerControllerBase.SetCamera(TPSCamera);
            if (TPSCamera != null) TPSCamera.gameObject.SetActive(true);
            else
                throw new UnityException("You have to assign a TPSCamera");
            //Canvas.worldCamera = TPSCamera;
        }
        else if (Choose2D)
        {
            PlayerControllerBase.SetCamera(Camera2D);
            if (Camera2D != null) Camera2D.gameObject.SetActive(true);
            else
                throw new UnityException("You have to assign a Camera2D");
            //Canvas.worldCamera = Camera2D;
        }
        else
        {
            throw new UnityException("You have to choose a camerafor the player");
        }
    }
}