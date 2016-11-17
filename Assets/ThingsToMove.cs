using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThingsToMove : MonoBehaviour
{
    public GameObject GameObject;



#if UNITY_EDITOR

    public List<GameObject> thingsToMove;
    public List<Transform> whereToMoveThem;


    void Start()
    {
        foreach (GameObject thing in thingsToMove)
        {
            thing.transform.position = whereToMoveThem[thingsToMove.IndexOf(thing)].position;
        }
    }

#endif
}
