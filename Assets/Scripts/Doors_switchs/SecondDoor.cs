using UnityEngine;

public class SecondDoor : MonoBehaviour
{
    public Switch _switch;
    Animator _animator;


    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        _animator.SetTrigger(OtherAnimationParams.OpenDoor.ToString());
        _switch.GoGreen();
    }


    public void CloseDoor()
    {
        _animator.SetTrigger(OtherAnimationParams.CloseDoor.ToString());
        _switch.ResetColor();
    }
}