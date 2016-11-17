using UnityEngine;


public class ActionTrigger : MonoBehaviour
{
    protected BoxCollider Collider;
    void Awake()
    {
        Collider = GetComponent<BoxCollider>();

    }
}


