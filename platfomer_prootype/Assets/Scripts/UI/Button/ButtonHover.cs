using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Button
{
    /// <summary>
    /// Simple script for managing cursor change when we hover over the button
    /// </summary>
    public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField] private Texture2D pointerCursor;

        public void OnPointerEnter(PointerEventData eventData)
        {
            Cursor.SetCursor(pointerCursor, Vector2.zero, CursorMode.Auto);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ResetCursor();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            ResetCursor();
        }
        
        private void ResetCursor()
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

}
