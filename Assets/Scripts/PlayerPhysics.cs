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

    // Unified entry point for timed hazard effects (callable via UnityEvent or script)
    public void ApplyTimedEffect(string effectType)
    {
        if (hazardEffectCoroutine != null)
        {
            StopCoroutine(hazardEffectCoroutine);
        }

        hazardEffectCoroutine = StartCoroutine(EffectDurationRoutine(effectType));
    }

    private IEnumerator EffectDurationRoutine(string effectType)
    {
        // Apply effect immediately upon trigger
        if (effectType == "Ice")
        {
            // Ice: Reduce drag/decay by half. 
            inertiaRetention = 1f - ((1f - defaultInertia) * 0.5f);
        }
        else if (effectType == "Thorns")
        {
            // Thorns: Slow speed gain drastically
            activeSpeedGain = 3f;
            inertiaRetention = defaultInertia; // Restore regular inertia
        }

        // Wait 5 seconds
        yield return new WaitForSeconds(5f);

        //  revert to original values once time is reached
        activeSpeedGain = defaultSpeedGain;
        inertiaRetention = defaultInertia;
    }

    // Create public events that can be referenced by our hazards
    public void ApplyIceEffect() => ApplyTimedEffect("Ice");
    public void ApplyThornsEffect() => ApplyTimedEffect("Thorns");
}