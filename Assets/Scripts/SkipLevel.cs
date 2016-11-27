using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SkipLevel : MonoBehaviour
{



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
