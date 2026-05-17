using UnityEngine;

public class PCNavigator : MonoBehaviour
{
    public float speed = 3.5f;
    public float sensitivity = 2.0f;
    
    private CharacterController modifier;
    private float rotationX = 0f;

    void Start()
    {
        modifier = GetComponent<CharacterController>();
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f); 

        transform.Rotate(Vector3.up * mouseX);
        
        float moveForward = Input.GetAxis("Vertical");
        float moveSideways = Input.GetAxis("Horizontal");

        Vector3 forward = transform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = transform.right;
        right.y = 0;
        right.Normalize();

        Vector3 direction = (forward * moveForward + right * moveSideways) * speed;

        if (!modifier.isGrounded)
        {
            direction.y = -9.81f;
        }

        modifier.Move(direction * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}