using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed;

    private Vector2 movementDirection = Vector2.zero;

    private Vector2 lastMousePosition = Vector2.zero;

    private Camera mainCamera;

    void Start()
    {
        lastMousePosition = Mouse.current.position.ReadValue();
        mainCamera = Camera.main;
    }

    void Update()
    {
        transform.position += (Vector3)movementDirection * speed * Time.deltaTime;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        // Read the pointer
        Vector2 screenPosition = context.ReadValue<Vector2>();
        lastMousePosition = screenPosition;

        // Convert screen position to world position
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(
            new Vector3(screenPosition.x, screenPosition.y, mainCamera.nearClipPlane)
        );

        Vector2 direction = (Vector2)worldPosition - (Vector2)transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();
        //Debug.Log(movementDirection);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack! " + context.phase);
    }
}