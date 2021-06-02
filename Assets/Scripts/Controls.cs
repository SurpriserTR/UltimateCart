using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UltimateCart {
    public class Controls : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler {
        public RectTransform joyPad;
        [Range(0, 1)] public float maxHorizontalDragPercent = 0.128f;
        [Range(0, 1)] public float maxVerticalDragPercent = 0.072f;
        public Animator joyPadAnimator;
        public string horizontalParamName;
        public string verticalParamName;
        public float animSpeed = 12;
        
        public IControllable Controllable { private get; set; }

        private const int c_nonPointer = -2973642;
        private int _lastPointerId;

        private Vector2 _dragDirection;
        private Vector2 _lastPoint;

        private void Awake() {
            _lastPointerId = c_nonPointer;
            Controllable = FindObjectOfType<Car>();
        }

        public void OnPointerDown(PointerEventData eventData) {
            if (_lastPointerId == c_nonPointer) {
                _lastPointerId = eventData.pointerId;
                _lastPoint = eventData.position;
                joyPad.anchoredPosition = eventData.position;
            }
        }

        void IDragHandler.OnDrag(PointerEventData eventData) {
            if (_lastPointerId == eventData.pointerId) Drag(eventData.position);
        }

        public void OnPointerUp(PointerEventData eventData) {
            if (eventData.pointerId == _lastPointerId) {
                _lastPointerId = c_nonPointer;
                _dragDirection = Vector2.zero;
            }
        }

        private void Drag(Vector2 mousePos) {
            var diff = mousePos - _lastPoint;
            _dragDirection.x = Normalize(Mathf.Abs(diff.x), 0, maxHorizontalDragPercent * Screen.width) * Mathf.Sign(diff.x);
            _dragDirection.y = Normalize(Mathf.Abs(diff.y), 0, maxVerticalDragPercent * Screen.height) * Mathf.Sign(diff.y);
        }

        private float Normalize(float value, float minValue, float maxValue, float minNormalizedValue = 0, float maxNormalizedValue = 1) {
            return Mathf.Clamp(NormalizeUnclamped(value, minValue, maxValue, minNormalizedValue, maxNormalizedValue), minNormalizedValue, maxNormalizedValue);
        }

        private float NormalizeUnclamped(float value, float minValue, float maxValue, float minNormalizedValue = 0, float maxNormalizedValue = 1) {
            return (value - minValue) / (maxValue - minValue) * (maxNormalizedValue - minNormalizedValue) + minNormalizedValue;
        }

        private void FixedUpdate() {
            if (Controllable != null) {
                Controllable.Move(_dragDirection);
            }
        }

        private void Update() {
            if (_dragDirection == Vector2.zero) {
                joyPad.gameObject.SetActive(false);
            }
            else {
                joyPadAnimator.SetFloat(horizontalParamName, Mathf.MoveTowards(joyPadAnimator.GetFloat(horizontalParamName), _dragDirection.x, animSpeed * Time.deltaTime));
                joyPadAnimator.SetFloat(verticalParamName, Mathf.MoveTowards(joyPadAnimator.GetFloat(verticalParamName), _dragDirection.y, animSpeed * Time.deltaTime));
                joyPad.gameObject.SetActive(true);
            }
        }
        public interface IControllable {
            public void Move(Vector2 dragDirection);
        }
    }
}