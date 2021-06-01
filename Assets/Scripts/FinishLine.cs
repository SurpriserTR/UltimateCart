using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider col) {
        Debug.Log("Finished!");
    }
}
