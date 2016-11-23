using UnityEngine;
using UnityEngine.SceneManagement;

public class Persistance : MonoBehaviour
{
    Persistance instance;

    public bool AlreadyDiedScene02;
    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Scene02")
        {

            if (instance == null)
            {
                DontDestroyOnLoad(gameObject);
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }



}
