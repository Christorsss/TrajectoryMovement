using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Utilities
{
    public class MouseRegistrer : MonoBehaviour
    {
        public Action<Vector3> OnMouseClick;

        private Camera _mainCamera;
        private Vector3 _inputPosition;

        public Vector3 MouseWorldPosition => _inputPosition;

        public void Initialize()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _inputPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                _inputPosition.z = 0;
                OnMouseClick?.Invoke(_inputPosition);
            }
        }
    }
}