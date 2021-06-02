using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UltimateCart {
    public class Car : MonoBehaviour, Controls.IControllable {
        
        public float maxSteerAngle = 30;
        public float motorForce = 50;
        public float idleBreakTorque = 50;
        public WheelCollider frontLeftWheelCol; 
        public WheelCollider frontRightWheelCol;
        public WheelCollider backLeftWheelCol; 
        public WheelCollider backRightWheelCol;
        public Transform frontLeftWheelVisual; 
        public Transform frontRightWheelVisual;
        public Transform backLeftWheelVisual; 
        public Transform backRightWheelVisual;

        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";
        
        private float _horizontalInput;
        private float _verticalInput;
        private float _steeringAngle;
        private GameManager _gameManager;

        private void Awake() {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void CheckForFailureHit() {
            CheckForFailureHit(frontLeftWheelCol);
            CheckForFailureHit(frontRightWheelCol);
            CheckForFailureHit(backLeftWheelCol);
            CheckForFailureHit(backRightWheelCol);
        }
        
        private void CheckForFailureHit(WheelCollider coll) {
            if (coll.GetGroundHit(out WheelHit hit)) {
                if (hit.collider.gameObject.CompareTag("Fail")) {
                    _gameManager.FinishGame(false);
                }
            }
        }

        private void GetInput() {
            _horizontalInput = Input.GetAxis(HorizontalAxisName);
            _verticalInput = Input.GetAxis(VerticalAxisName);
        }

        private void Steer() {
            _steeringAngle = maxSteerAngle * _horizontalInput;
            frontLeftWheelCol.steerAngle = _steeringAngle;
            frontRightWheelCol.steerAngle = _steeringAngle;
        }

        private void Accelerate() {
            frontLeftWheelCol.motorTorque = _verticalInput * motorForce;
            frontRightWheelCol.motorTorque = _verticalInput * motorForce;
            if (_verticalInput == 0) {
                frontLeftWheelCol.brakeTorque = idleBreakTorque;
                frontRightWheelCol.brakeTorque = idleBreakTorque;
            }
            else {
                frontLeftWheelCol.brakeTorque = 0;
                frontRightWheelCol.brakeTorque = 0;
            }
        }

        private void UpdateWheelPoses() {
            UpdateWheelPose(frontLeftWheelCol, frontLeftWheelVisual);
            UpdateWheelPose(frontRightWheelCol, frontRightWheelVisual);
            UpdateWheelPose(backLeftWheelCol, backLeftWheelVisual);
            UpdateWheelPose(backRightWheelCol, backRightWheelVisual);
        }

        private void UpdateWheelPose(WheelCollider col, Transform transform)
        {
            Vector3 pos = transform.position;
            Quaternion rot = transform.rotation;

            col.GetWorldPose(out pos, out rot);

            transform.position = pos;
            transform.rotation = rot;
        }
        
        public void Move(Vector2 dragDirection) {
            CheckForFailureHit();
            _horizontalInput = dragDirection.x;
            _verticalInput = dragDirection.y;
            if (dragDirection == Vector2.zero) {
                GetInput();
            }
            Steer();
            Accelerate();
            UpdateWheelPoses();
        }
    }
}