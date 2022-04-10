using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float animationSpeed = 5f;
    private float leftEdge;
    private Rigidbody2D rb;

    void Awake()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var position = rb.position + new Vector2(-1f * animationSpeed, 0f) * Time.deltaTime;
        rb.MovePosition(position);

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }

    }
}
