using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;



public class RagdollSwitch : MonoBehaviour
{
    public GameObject bipedRootGameobject;
    public bool EnableRagdollColliders;
    public Rigidbody rigibodyToPropulseAtDeath;


    private List<Collider> _colliders;
    private List<CharacterJoint> _characterJoints;
    private List<GameObject> gmObjectsWithRB;
    private IEnumerator killingCoroutine;


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
            killingCoroutine = Kill();
            StartCoroutine(killingCoroutine);
        }

    }




    /// <summary>
    /// Permet de killer avec la touche K
    /// </summary>
    IEnumerator Kill(float killingJummpForce = 20000)
    {
        if (Application.isEditor)
        {
            //Todo impulsion vers le haut
            Rigidbody gameObjectRB = GetComponent<Rigidbody>();

            if (rigibodyToPropulseAtDeath == null)
            {
                rigibodyToPropulseAtDeath = gameObjectRB;
            }

            gameObjectRB.AddForce(Vector3.up * killingJummpForce / 2);
            gameObjectRB.AddTorque(Vector3.left * 30000);

            yield return new WaitForSeconds(0.5f);
            SetAllRagDollColliders(true);
            MakeRBsNotPhysic(false);
            GetComponent<Animator>().enabled = false;
            GetComponent<Collider>().enabled = false;
            Destroy(gameObjectRB);

            rigibodyToPropulseAtDeath.AddForce(Vector3.up * killingJummpForce);


            Debug.Log("killed the character with kill method");
            DebugPrintCollidersAndJoints();
            GetComponent<Player>().Alive = false;
            //Debug.Break();

        }
    }




}
