using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class LineMaker : MonoBehaviour
{
    Coroutine growCoroutine;
    LineRenderer lineRenderer;
    
    public float growDuration = 1f; 
    public Vector3 startPosition;
    public Vector3 endPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            Debug.Log("LineMaker does not have a LineRenderer component.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ONJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // If there is already a grow coroutine running, stop it to restart smoothly
            if (growCoroutine != null)
            {
                StopCoroutine(growCoroutine);
            }

            // Start the new coroutine
            growCoroutine = StartCoroutine(GrowUpdate());
        }
    }

    IEnumerator GrowUpdate()
    {
        float t = 0;
        
        // Ensure we have points to render
        lineRenderer.positionCount = 2;
        
        // Initialize both ends at start position so it starts from "zero" length
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, startPosition);

        while (t < growDuration)
        {
            t += Time.deltaTime;
            
            // Update the second point to interpolate between start and end
            Vector3 currentSecondPosition = Vector3.Lerp(startPosition, endPosition, t / growDuration);
            lineRenderer.SetPosition(1, currentSecondPosition);

            yield return null;
        }
        
        // Ensure final position is exact
        lineRenderer.SetPosition(1, endPosition);
    }
}