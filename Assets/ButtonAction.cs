using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    public FadeGUI _fadeGui;




    public int firstScene;

    public void LoadFirstLevel()
    {
        _fadeGui.BeginFade(1);

        StartCoroutine(FadeOutDone(1));


    }




    IEnumerator FadeOutDone(int resultWanted)
    {
        yield return new WaitUntil(() => _fadeGui.alpha == resultWanted);
        SceneManager.LoadSceneAsync(firstScene, LoadSceneMode.Single);

    }
}
