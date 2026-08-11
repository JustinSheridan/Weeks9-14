using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public PlayerPhysics playerPhysics;

    private Vector2 movementDirection = Vector2.zero;

    void Update()
    {
        // Only edit movement speed if the player is moving / Not null
        if (playerPhysics != null)
        {
            playerPhysics.SetMovementInput(movementDirection);
        }
    }

    // Continuous action mapped to Player Input 
    public void OnMove(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();
    }
    // Commented out old code
    /*
    private Vector2 lastMousePosition = Vector2.zero;
    private Camera mainCamera;

    void Start()
    {
        lastMousePosition = Mouse.current.position.ReadValue(); // Violates constraint
        mainCamera = Camera.main;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 screenPosition = context.ReadValue<Vector2>();
        lastMousePosition = screenPosition;
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, mainCamera.nearClipPlane));
        Vector2 direction = (Vector2)worldPosition - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack! " + context.phase);
    }
    */
}