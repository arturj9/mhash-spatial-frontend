using UnityEngine;

public class PCNavigator : MonoBehaviour
{
    public float speed = 3.5f;
    public float sensitivity = 2.0f;
    
    private CharacterController modifier;
    
    // Variáveis para guardar para onde você está olhando
    private float rotationX = 0f;
    private float rotationY = 0f; 

    void Start()
    {
        modifier = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        
        // Salva a direção que você já está olhando no começo do jogo
        rotationY = transform.eulerAngles.y;
    }

    void Update()
    {
        // 1. Lê o movimento do mouse
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // 2. Calcula as rotações (X é vertical, Y é horizontal)
        rotationY += mouseX;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f); 
        
        // 3. O SEGREDO: Aplica as duas rotações de uma vez só no objeto!
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
        
        // 4. Movimentação (WASD)
        float moveForward = Input.GetAxis("Vertical");
        float moveSideways = Input.GetAxis("Horizontal");

        Vector3 forward = transform.forward;
        forward.y = 0; // Garante que você não voe se olhar para cima e apertar W
        forward.Normalize();

        Vector3 right = transform.right;
        right.y = 0;
        right.Normalize();

        Vector3 direction = (forward * moveForward + right * moveSideways) * speed;

        // Gravidade
        if (!modifier.isGrounded)
        {
            direction.y = -9.81f;
        }

        modifier.Move(direction * Time.deltaTime);

        // Destrava o mouse se apertar ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}