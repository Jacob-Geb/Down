using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ui
{
    class InteractableBase : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {

        public event Action shortPress;

        public void OnPointerDown(PointerEventData data)
        {

        }

        public void OnPointerUp(PointerEventData data)
        {
            // TODO diff longpress && shortPress
            onShortPress();
        }

        private void onShortPress()
        {
            if (shortPress != null)
                shortPress();
        }
    }
}
