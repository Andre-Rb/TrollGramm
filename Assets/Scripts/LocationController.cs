using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationController : MonoBehaviour
{

    public string locationString;




    void Start()
    {
        SceneManager.sceneLoaded += UpdateLocation;
        if (locationString == null)
        {
           
        }
    }

    private void UpdateLocation(Scene arg0, LoadSceneMode loadSceneMode)
    {
        locationString = SceneManager.GetActiveScene().name;
        Debug.Log(arg0 + " has been loaded");

    }
}
