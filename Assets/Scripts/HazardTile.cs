using UnityEngine;
using UnityEngine.Events;

public class HazardTile : MonoBehaviour {
    public enum EffectType { Ice, Thorns }
    
    public SpriteRenderer targetRenderer; 
    public UnityEvent onTriggerEnter;     // Public event to link to the hazard scripts
    private bool isTriggered = false;
    
    public PlayerPhysics playerRef;       // Assign in Inspector to handle physics timing
    public EffectType activeEffect;       // Set to Ice or Thorns in Inspector

    void Update() {
        if (targetRenderer == null) return;

        // Bounds check if player is inside
        bool isInside = targetRenderer.bounds.Contains(transform.position);

        if (isInside && !isTriggered)
        {
            // Trigger the timed physics effect
            if (playerRef != null)
            {
                playerRef.ApplyTimedEffect(activeEffect.ToString());
            }

            isTriggered = true;
            Debug.Log("HazardTile triggered: " + gameObject.name);
        }

        // Reset once player leaves bounds
        if (!isInside && isTriggered)
        {
            isTriggered = false;
        }
    }
}