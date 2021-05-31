using UltimateCart;
using UnityEngine;

public class Car : MonoBehaviour, Controls.IControllable {
    public float speed = 5;
    public float rotationSpeed = 60;
    
    private Rigidbody _rb;

    private void Awake() {
        _rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 dragDirection) {
        // if (dragDirection == Vector2.zero) return;
        
        var deltaTime = Time.deltaTime;
        
        if (dragDirection.y > 0)
        {
            transform.Translate(Vector3.forward * (speed * deltaTime));
        }
        if (dragDirection.y < 0)
        {
            transform.Translate(Vector3.back * (speed * deltaTime));
        }
        
        Quaternion deltaRotationRight = Quaternion.Euler(Vector3.up * (dragDirection.x * (rotationSpeed * deltaTime)));
        _rb.MoveRotation(_rb.rotation * deltaRotationRight);

        // _rb.AddForce(transform.forward * (dragDirection.y * accelerationSpeed));
        //
        // var angle = -Vector2.SignedAngle(Vector2.up, dragDirection);
        // var eulerAngles = _rb.rotation.eulerAngles;
        // eulerAngles.y = Mathf.MoveTowardsAngle(eulerAngles.y, angle, rotationSpeed * deltaTime);
        // _rb.MoveRotation(Quaternion.Euler(eulerAngles));
    }
}
