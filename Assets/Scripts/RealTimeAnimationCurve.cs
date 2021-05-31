using System;
using UnityEngine;

namespace UltimateCart {
    [Serializable]
    public class RealtimeAnimationCurve {
        public AnimationCurve curve;

        public float Length => _endTime;

        private float _timer;
        private float _endTime;

        public void DetermineCurveEndTime() {
            _endTime = curve.keys[curve.keys.Length - 1].time;
        }

        public void MoveClamped(float deltaTime) {
            _timer = Mathf.Clamp(_timer - deltaTime, 0, _endTime);
        }

        public bool TryMoveForward(float deltaTime) {
            if (_timer == _endTime) return false;

            _timer = Mathf.Min(_endTime, _timer + deltaTime);
            return true;
        }

        public float Evaluate() {
            return curve.Evaluate(_timer);
        }

        public void Reset() {
            _timer = 0;
        }
    }
}

