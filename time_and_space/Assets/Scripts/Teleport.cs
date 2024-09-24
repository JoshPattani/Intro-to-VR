using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private GameObject playerOrigin;
    [SerializeField]
    private LayerMask teleportMask;
    [SerializeField]
    private InputActionReference teleportButton;
    
    void Start() {
        teleportButton.action.performed += DoRaycast;
    }

    void DoRaycast (InputAction.CallbackContext __) {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, teleportMask)) {
            // Debugging
            // Debug.Log("Teleport position: " + teleportPosition);
            Debug.Log(hit.collider.gameObject.name);

            // Teleport
            playerOrigin.transform.position = hit.collider.gameObject.transform.position;
        }
    }
}
