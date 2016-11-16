using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeGUI : MonoBehaviour
{

    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.1f;

    private int drawDepth = -1000;
    public float alpha = -1f;
    private int fadeDirection = -1;


    private bool _isFading;
    void Awake()
    {


        if (fadeOutTexture == null)
        {
            fadeOutTexture = new Texture2D(1, 1, TextureFormat.ARGB32, true);
            fadeOutTexture.SetPixel(0, 0, Color.black);
            fadeOutTexture.Apply();

            fadeOutTexture.name = "GeneratedBlackTexture";
        }
    }

    private void StartFadeOut(Scene arg0, LoadSceneMode arg1)
    {
        BeginFade(-1);

    }



    // ReSharper disable once InconsistentNaming
    // ReSharper disable once UnusedMember.Local
    private void OnGUI()
    {

        alpha += fadeDirection * fadeSpeed * Time.deltaTime;

        alpha = Mathf.Clamp01(alpha);

        GUI.depth = drawDepth;


        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture, ScaleMode.StretchToFill);
    }

    public float BeginFade(int direction)
    {
        fadeDirection = direction;


        return (fadeSpeed);

    }


}
