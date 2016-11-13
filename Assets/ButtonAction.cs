using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    private FadeGUI _fadeGui;


    void Start()
    {
        _fadeGui = GetComponent<FadeGUI>();

    }


    public int firstScene;

    public void LoadFirstLevel()
    {
        SceneManager.LoadSceneAsync(firstScene, LoadSceneMode.Single);
        _fadeGui.gameObject.SetActive(true);
        _fadeGui.BeginFade(1);


    }

}
