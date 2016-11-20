using UnityEngine;
using System.Collections;

public class ThirdDoor : MonoBehaviour
{
    Animator _animator;


    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        _animator.SetTrigger(OtherAnimationParams.OpenDoor.ToString());
    }


    public void CloseDoor()
    {
        _animator.SetTrigger(OtherAnimationParams.CloseDoor.ToString());
    }
}