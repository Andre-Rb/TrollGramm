using UnityEngine;


public class DoorClosingTrigger : ActionTrigger
{


    public Animator DoorAnimator;
    public void OnCollisionEnter(Collision collision)
    {
        DoorAnimator.SetTrigger(OtherAnimationParams.CloseDoor.ToString());

        Collider.enabled = false;
    }

}
