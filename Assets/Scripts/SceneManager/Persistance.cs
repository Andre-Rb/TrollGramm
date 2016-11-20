using UnityEngine;

public class Persistance : MonoBehaviour
{
    static Persistance instance;

    public  bool IsFirstTryScene02;
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


}
