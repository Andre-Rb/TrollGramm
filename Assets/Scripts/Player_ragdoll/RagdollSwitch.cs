using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class RagdollSwitch : MonoBehaviour
{
    public GameObject bipedRootGameobject;
    public bool EnableRagdollColliders;
    public Rigidbody rigibodyToPropulseAtDeath;


    private List<Collider> _colliders;
    private List<CharacterJoint> _characterJoints;
    private List<GameObject> gmObjectsWithRB;
    private IEnumerator spinningRoutine;


    void Start()
    {
        _colliders = bipedRootGameobject.GetComponentsInChildren<Collider>().ToList();
        _characterJoints = bipedRootGameobject.GetComponentsInChildren<CharacterJoint>().ToList();


        gmObjectsWithRB = new List<GameObject>();
        foreach (Rigidbody child in bipedRootGameobject.GetComponentsInChildren<Rigidbody>())
        {
            gmObjectsWithRB.Add(child.gameObject);
        }

        DebugPrintCollidersAndJoints();

        Debug.Log(Application.isEditor);

        SetAllRagDollColliders(EnableRagdollColliders);
        MakeRBsNotPhysic(true);


    }

    private void DebugPrintCollidersAndJoints()
    {
        Debug.Log("Found " + _colliders.Count.ToString() + " colliders and " + _characterJoints.Count.ToString() + " joints and " + gmObjectsWithRB.Count.ToString() + " gameObjects With a RB.");
    }

    private void SetAllRagDollColliders(bool b)
    {

        foreach (Collider collider in _colliders)
        {
            collider.enabled = b;

        }


    }

    void MakeRBsNotPhysic(bool b)
    {
        foreach (GameObject gameObject in gmObjectsWithRB)
        {
            Rigidbody component = gameObject.GetComponent<Rigidbody>();
            component.isKinematic = b;
            component.detectCollisions = !b;

        }
    }


    public void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            Kill();
            spinningRoutine = Spinning(20000f);

            StartCoroutine(spinningRoutine);
        }

    }




    /// <summary>
    /// Permet de killer avec la touche K
    /// </summary>
    void Kill(float killingJummpForce = 2000)
    {
        if (Application.isEditor)
        {
            Rigidbody gameObjectRB = GetComponent<Rigidbody>();

            SetAllRagDollColliders(true);
            MakeRBsNotPhysic(false);
            GetComponent<Animator>().enabled = false;
            GetComponent<Collider>().enabled = false;
            Destroy(gameObjectRB);
            GetComponent<Player>().Alive = false;
            Debug.Log("killed the character with kill method");
            rigibodyToPropulseAtDeath.AddForce(Vector3.up * killingJummpForce);




        }
    }

    IEnumerator Spinning(float force)
    {
        Debug.Log(rigibodyToPropulseAtDeath.maxAngularVelocity);
        rigibodyToPropulseAtDeath.maxAngularVelocity = 200;
        Debug.Log(rigibodyToPropulseAtDeath.maxAngularVelocity);

        for (int i = 0; i < 5; i++)
        {

            rigibodyToPropulseAtDeath.AddTorque(Vector3.right * force);
            rigibodyToPropulseAtDeath.AddTorque(Vector3.up * force);
            yield return new WaitForSeconds(0.1f);
        }
    }


}
