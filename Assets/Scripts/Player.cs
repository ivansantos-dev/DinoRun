using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;

    [SerializeField] private float jumpMultiplier = 5f;
    [SerializeField] private float fallMultiplier = 1f;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;

    private GameManager gameManager;

    private bool jumpPressed;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Hit space" + gameManager.isGameOver());
            if (gameManager.isGameOver())
            {
                gameManager.Play();
                jumpPressed = false;
            }
            else if (IsGrounded())
            {
                jumpPressed = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (rigidBody.velocity.y < 0)
        {
            rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }


        if (jumpPressed)
        {
            rigidBody.velocity = Vector2.up * jumpMultiplier;
            jumpPressed = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
        {
            gameManager.GameOver();
        }

    }

    private bool IsGrounded()
    {
        var boxCast = Physics2D.BoxCast(
            boxCollider.bounds.center,
            boxCollider.bounds.size,
            0f,
            Vector2.down,
            .1f,
            platformLayerMask

        );
        return boxCast.collider != null;
    }

}
