using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private float sensitivity = 0.1f;
    [SerializeField] private Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 delta = Mouse.current.delta.ReadValue();
        Debug.Log("X: " + delta.x + " Y: " + delta.y);

        float mouseX = delta.x * sensitivity;
        float mouseY = delta.y * sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}