using TMPro;
using UnityEngine;

namespace PsyCurio
{
    [RequireComponent(typeof(CanvasGroup))]

    public class UISpeechBubble : MonoBehaviour
    {
        #pragma warning disable CS0649
        private CanvasGroup _canvasGroup;
        [SerializeField] private TextMeshProUGUI _bubbleTxt;
        
        void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Show(string text)
        {
            _bubbleTxt.text = text;
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
            Invoke("End",3f);
        }

        private void End()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
        
    }
}