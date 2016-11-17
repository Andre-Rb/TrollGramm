using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Triggers.Dialogues
{
    public class SubtitlesController : MonoBehaviour
    {
        public Text speaker;
        public Text textComponent;


        public void SetActive(bool b)
        {
            gameObject.SetActive(b);

        }

    }
}
