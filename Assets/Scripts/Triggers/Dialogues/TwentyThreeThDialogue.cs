using UnityEngine;

public class TwentyThreeThDialogue : DialogueTrigger
{
    public Animator Animator;


    public GameObject blueScreen;


    private void OnTriggerEnter(Collider other)
    {
        PlayDialogue();
        Invoke("StartBreakingRuleAnim", 5.5f);
        Invoke("ShowBlueScreen", 8);
    }

    void StartBreakingRuleAnim()
    {
        Animator.SetTrigger("BreakTrigger");
    }



    void ShowBlueScreen()
    {
        blueScreen.SetActive(true);

        //Invoke("QuitGame", 5);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
