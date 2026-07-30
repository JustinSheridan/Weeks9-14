using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class LineMaker : MonoBehaviour
{
    Coroutine growCoroutine;
    LineRenderer lineRenderer;
    
    public float growDuration = 1f; 
    public Vector3 startPosition;
    
    //Where the mouse is
    public Vector3 endPosition;

    // Where the gameobject is when teleported
    private Vector3 objectPosition;

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
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldMousePosition.z = 0f; // Lock to the Z-plane (standard for 2D/isometric)

        // Also store this position as our line target
        endPosition = worldMousePosition;
        

        // Start the line drawing coroutine if not already running
        if (growCoroutine != null)
        {
            StopCoroutine(growCoroutine);
        }
        growCoroutine = StartCoroutine(GrowUpdate());
    }

    // public void ONJump(InputAction.CallbackContext context)
    // {
    //     if (context.performed)
    //     {
    //         // If there is already a grow coroutine running, stop it to restart smoothly
    //         if (growCoroutine != null)
    //         {
    //             StopCoroutine(growCoroutine);
    //         }
    //
    //         // Start the new coroutine
    //         growCoroutine = StartCoroutine(GrowUpdate());
    //     }
    // }

    public void ONAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            transform.position = endPosition;
            objectPosition = endPosition;
        }
    }

    IEnumerator GrowUpdate()
    {
        // Comment out, the line is always drawn
        
        // float t = 0;
        //
        // // Ensure we have points to render
        // lineRenderer.positionCount = 2;
        //
        // // Initialize both ends at start position so it starts from "zero" length
        // lineRenderer.SetPosition(0, startPosition);
        // lineRenderer.SetPosition(1, startPosition);
        //
        // while (t < growDuration)
        // {
        //     t += Time.deltaTime;
        //     
        //     // Update the second point to interpolate between start and end
        //     Vector3 currentSecondPosition = Vector3.Lerp(startPosition, endPosition, t / growDuration);
        //     lineRenderer.SetPosition(1, currentSecondPosition);
        //
        //     yield return null;
        // }
        
        // Set position index one and return null
        lineRenderer.SetPosition(1, endPosition-objectPosition);
        yield return null;
    }
}