using System.Collections.Generic;
using UnityEngine;

public class ThingsToDisable : MonoBehaviour
{
#if UNITY_EDITOR
    public List<GameObject> List;

    void Start()
    {
        DisableAll();
    }

    private void DisableAll()
    {
        foreach (GameObject o in List)
        {
            o.SetActive(false);
        }
    }

#endif
}