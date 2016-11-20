using UnityEngine;

public class Persistance : MonoBehaviour
{
    static Persistance instance;

    public  bool AlreadyDiedScene02;
    void Awake()
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
