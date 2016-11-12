using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;



public class RagdollSwitch : MonoBehaviour
{
    public GameObject bipedRootGameobject;
    public bool EnableRagdollColliders;


    private List<Collider> _colliders;
    private List<CharacterJoint> _characterJoints;


    void Start()
    {
        _colliders = bipedRootGameobject.GetComponentsInChildren<Collider>().ToList();
        _characterJoints = bipedRootGameobject.GetComponentsInChildren<CharacterJoint>().ToList();
        Debug.Log(Application.isEditor);

        SetAllRagDollColliders(EnableRagdollColliders);

    }

    private void DebugPrintCollidersAndJoints()
    {
        Debug.Log("Found " + _colliders.Count.ToString() + " colliders and " + _characterJoints.Count.ToString() + " joints.");
    }

    private void SetAllRagDollColliders(bool b)
    {

        foreach (Collider collider in _colliders)
        {
            collider.enabled = b;

        }


    }

    public void Update()
    {


        if (Input.GetKeyDown(KeyCode.K))
        {
            Kill();
        }


    }


    /// <summary>
    /// Permet de killer avec la touche K ( que dans l'editeur
    /// </summary>
    void Kill()
    {
        if (Application.isEditor)
        {
            SetAllRagDollColliders(true);
            GetComponent<Animator>().enabled = false;
            GetComponent<Collider>().enabled = false;
            Destroy(GetComponent<Rigidbody>());
            Debug.Log("killed the character with kill method");
            DebugPrintCollidersAndJoints();

            //Debug.Break();

        }
    }
}
