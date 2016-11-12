using UnityEngine;



public class RagdollSwitch : MonoBehaviour
{
    public GameObject bipedRootGameobject;

    List
    private List<CapsuleCollider> _colliders;
    private List<CharacterJoint> _characterJoints;
    // Use this for initialization
    void Start()
    {

        _colliderList = bipedRootGameobject.GetComponentsInChildren<CapsuleCollider>();
        _characterJoints = bipedRootGameobject.GetComponentsInChildren<CharacterJoint>();
        Debug.Log("sqd");

    }

    // Update is called once per frame
    void Update()
    {

    }
}
