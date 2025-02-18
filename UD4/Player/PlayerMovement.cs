using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 moveDirection;

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.y = Input.GetAxis("Vertical");
        transform.position += (Vector3)moveDirection * Time.deltaTime * speed;
    }
}
