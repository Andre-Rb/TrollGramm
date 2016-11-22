using UnityEngine;
using System.Collections.Generic;

public class FilterSwitcher : MonoBehaviour
{


    Camera _playerCamera;
    public PlayerController3D PlayerController3D;

    public GameObject redModelCube;
    public GameObject blueModelCube;

    public GameObject redFilter;
    public GameObject blueFilter;
    private List<GameObject> _listFilters;

    private int redLayerMask;
    private int blueLayerMask;
    private int neitherLayerMask;
    void Start()
    {
        //Debug.Log("Camera culling mask are : " + PlayerCamera.cullingMask);
        //Debug.Log("Blue culling mask are : " + redModelCube.layer);
        //Debug.Log("Red culling mask are : " + blueModelCube.layer);
        ////PlayerCamera.cullingMask = 8;
        //Debug.Log("Camera culling mask are : " + PlayerCamera.cullingMask);
        //Debug.Log("~8  " + ~8);

        _playerCamera = PlayerController3D.GetCamera();

        redLayerMask = 1 << redModelCube.layer;
        blueLayerMask = 1 << blueModelCube.layer;
        neitherLayerMask = redModelCube.layer + redModelCube.layer;
        Debug.Log("Neither culling mask are : " + neitherLayerMask);
        Debug.Log("Neither culling mask are : " + neitherLayerMask);


        _listFilters = new List<GameObject>
        {
            redFilter,
       blueFilter};
        NormalView();
    }




    void Update()
    {

        //Vue Rouge
        if (/*Input.GetKeyDown(KeyCode.R) || */Input.GetButtonDown("RedFilter"))
        {
            RedView();

        }

        //Vue Bleue
        if (/*Input.GetKeyDown(KeyCode.B) || */Input.GetButtonDown("BlueFilter"))
            BlueView();
        // Vue Normale
        if (/*Input.GetKeyDown(KeyCode.N) ||*/ Input.GetButtonDown("NormalFilter"))
            NormalView();
    }

    private void RedView()
    {
        SwitchToFilter(Couleur.red);
        _playerCamera.cullingMask = ~redLayerMask;
    }

    private void BlueView()
    {
        SwitchToFilter(Couleur.blue);
        _playerCamera.cullingMask = ~blueLayerMask;
    }

    public void NormalView()
    {
        SwitchToFilter(Couleur.normal);
        _playerCamera.cullingMask = ~redLayerMask & ~blueLayerMask;
    }

    void SwitchToFilter(Couleur couleur)
    {

        foreach (GameObject listFilter in _listFilters)
        {
            listFilter.SetActive(false);
            Debug.Log(listFilter.name);
        }
        switch (couleur)
        {
            case Couleur.blue:
                blueFilter.SetActive(true);
                break;
            case Couleur.red:
                redFilter.SetActive(true);
                break;
            case Couleur.normal:
                break;
            default:
                throw new UnityException("Y'a une couille dans le pâté !");
        }
    }



}

enum Couleur
{
    blue,
    red,
    normal
}