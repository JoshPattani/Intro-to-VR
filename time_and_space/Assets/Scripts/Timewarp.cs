using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timewarp : MonoBehaviour
{
    [Header("Hand Reference")]
    public GameObject rightHandReference;

    // Variables to control time scaling
    public float minTimeScale = 0.1f; // Slowest time scale when moving
    public float maxTimeScale = 1.0f; // Normal time scale when stationary
    public float timeScaleMultiplier = 10.0f; // Multiplier to adjust sensitivity

    private Vector3 previousHandPosition = new Vector3(0,0,0);


    void Update()
    {
        if (rightHandReference != null)
        {
            Vector3 currentHandPosition = rightHandReference.transform.position;
            float distance = Vector3.Distance(previousHandPosition, currentHandPosition);
             // Calculate the new time scale based on the movement
            float newTimeScale = Mathf.Clamp(maxTimeScale - (distance * timeScaleMultiplier), minTimeScale, maxTimeScale);
            
            // Apply the new time scale
            Time.timeScale = newTimeScale;
            
            // Update the previous position for the next frame
            previousHandPosition = rightHandReference.transform.position;
        }
        else
        {
            Debug.LogError("Right Hand Reference is not assigned in TimeManager.");
        }
    }

    void OnDisable()
    {
        // Reset time scale to normal when the script is disabled or the game stops
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f;
    }
}

