using UnityEngine;

namespace PsyCurio
{
    public class SelectionManager : MonoBehaviour
    {
        [SerializeField] private string selectableTag = "Selectable";

        private IMouseOver _mouseOver;
        private Transform selection;
        private Camera cam;


        private void Awake()
        {
            cam = Camera.main;
        }


        private void Update()
        {
            if (selection != null  && _mouseOver != null) _mouseOver.OnDeselect();

            var ray = cam.ScreenPointToRay(Input.mousePosition);

            _mouseOver = null;

            if (Physics.Raycast(ray, out var hit))
            {
                selection = hit.transform;

                if (selection.CompareTag(selectableTag))
                {
                    // Debug.Log("hit  " +  hit.transform.name);
                    _mouseOver = selection.GetComponent<IMouseOver>();
                }
            }

            if (selection != null  && _mouseOver != null )
            {
                _mouseOver.OnSelect();
                if (Input.GetMouseButtonDown(0))
                {
                    _mouseOver.OnClick();
                }
            }
        }
    }
}