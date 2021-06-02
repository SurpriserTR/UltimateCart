using System;
using UnityEngine;

namespace UltimateCart {
    public class CameraManager : MonoBehaviour {
        [SerializeField] private Vector3 offset;
        [SerializeField] private Transform target;
        [SerializeField] private float translateSpeed;
        [SerializeField] private float rotationSpeed;

        private void Awake() {
            HandleTranslation(true);
            HandleRotation(true);
        }

        private void FixedUpdate() {
            HandleTranslation();
            HandleRotation();
        }

        private void HandleTranslation(bool immediately = false) {
            var targetPosition = target.TransformPoint(offset);
            if (immediately) {
                transform.position = targetPosition;
            }
            else {
                transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
            }
        }

        private void HandleRotation(bool immediately = false) {
            var direction = target.position - transform.position;
            var rotation = Quaternion.LookRotation(direction, Vector3.up);
            if (immediately) {
                transform.rotation = rotation;
            }
            else {
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}

