using UnityEngine;

public class TorqueTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    void Update()
    {

    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddTorque(Vector3.back * 10);
    }
}
