using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField] private Transform aim;
    private Vector2 facingDirection;

    private void Update()
    {
        HandleAiming();
    }

    private void HandleAiming()
    {
        facingDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        aim.position = transform.position + (Vector3)facingDirection.normalized;
    }

    public Vector2 GetFacingDirection()
    {
        return facingDirection;
    }
}
