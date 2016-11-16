using UnityEngine;
using System.Collections;

public class YCamera : MonoBehaviour
{
    public float speedRotate = 200.0f;
    public float max;
    public float min;



    void Start()
    {
        Debug.Log(transform.rotation.eulerAngles);
    }
    void Update()
    {
        Mouse();
    }

    void Mouse()
    {
        float mouseY = -Input.GetAxis("Mouse Y");

        float angleMax = Quaternion.Angle(transform.rotation, Quaternion.AngleAxis(0, transform.forward));
        //Debug.Log(Quaternion.Euler(mouseY * speedRotate, 0, 0) * transform.rotation);

        Quaternion foo = transform.rotation * Quaternion.Euler(mouseY * speedRotate, 0, 0);
        Debug.Log(foo.eulerAngles);
        if ((foo.eulerAngles.x <= 80 || foo.eulerAngles.x >= 280))
            transform.rotation = foo;

        //80 280 interdit
    }
}
