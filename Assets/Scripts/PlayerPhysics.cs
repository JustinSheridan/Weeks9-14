using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour
{
    // Consolidated public variables
    public float activeSpeedGain = 15f;       // Acceleration rate
    public float inertiaRetention = 0.92f;    // Inertia decay 

    private Vector2 inputMovement;
    private Vector2 velocity;
    private Coroutine slideParticleCoroutine;
    private Coroutine hazardEffectCoroutine;  

    // Cache defaults for safe reverting after duration expires
    private float defaultSpeedGain = 15f;
    private float defaultInertia = 0.92f;

    void Start()
    {
        // Initialize saved defaults immediately upon start
        defaultSpeedGain = activeSpeedGain;
        defaultInertia = inertiaRetention;
    }

    void Update()
    {
        // Player Input Speed / Change in position
        velocity += inputMovement * activeSpeedGain * Time.deltaTime;
        
        // Player's Speed Decaying
        velocity *= Mathf.Pow(inertiaRetention, Time.deltaTime);
        
        // Final Transformation using our velocity
        transform.position += (Vector3)velocity * Time.deltaTime;
    }

    public void SetMovementInput(Vector2 newInput)
    {
        inputMovement = newInput;
    }
}

