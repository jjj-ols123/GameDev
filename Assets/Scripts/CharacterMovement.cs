using UnityEngine;

public class IceMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public LayerMask wallLayer;

    private Vector2 moveDirection;
    private bool isMoving = false;

    void Update()
    {
        if (!isMoving)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            if (horizontal != 0)
            {
                StartMoving(new Vector2(horizontal, 0));
            }
            else if (vertical != 0)
            {
                StartMoving(new Vector2(0, vertical));
            }
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            Move();
        }
    }

    void StartMoving(Vector2 direction)
    {
        moveDirection = direction.normalized;
        isMoving = true;
    }

    void Move()
    {
        if (Physics2D.Raycast(transform.position, moveDirection, 0.8f, wallLayer))
        {
            isMoving = false;
            return;
        }

        transform.position += (Vector3)(moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
