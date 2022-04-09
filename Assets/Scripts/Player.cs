using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;

    [SerializeField] private float jumpMultiplier = 5f;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;

    private bool jumpPressed;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        if (jumpPressed)
        {
            rigidBody.velocity = Vector2.up * jumpMultiplier;
            jumpPressed = false;
        }
    }

    private bool IsGrounded()   {
        var boxCast = Physics2D.BoxCast(
            boxCollider.bounds.center,
            boxCollider.bounds.size,
            0f,
            Vector2.down,
            .1f,
            platformLayerMask

        );
        Debug.Log(boxCast.collider);
        return boxCast.collider != null;
   }

}
