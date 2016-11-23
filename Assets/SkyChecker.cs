using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkyChecker : MonoBehaviour
{
    private List<Collider> _currenttlyColliding;
    [SerializeField]
    private BackgroundScrolling BackgroundScrolling;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.Sky.ToString()))
        {
            _currenttlyColliding.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.Sky.ToString()))
        {
            _currenttlyColliding.Remove(other);
            if (_currenttlyColliding.Count == 0)
            {
               // BackgroundScrolling.GenerateANewSkyPlan();

            }
        }
    }


}
