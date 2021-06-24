using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Ball : MonoBehaviour
{
    public static UnityAction OnBallCollected;

    public bool Active {
        get {
            return circleCollider2D.enabled;
        }
        set {
            circleCollider2D.enabled = value;
            gameObject.SetActive(value);
        }
    }

    private int Score = 1;
    private CircleCollider2D circleCollider2D;
    private Rigidbody2D rigidBody2D;

    private Coroutine activeCoroutine;

    public void Awake()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void OnEnable()
    {
        Score = 1;
        activeCoroutine = null;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.CompareTo("Brick") == 0)
        {
            Score++;
        }
        else if(collision.collider.tag.CompareTo("Wall") == 0)
        {
            Score = 1;
        }
    }

    public void OnDisable()
    {
        
    }

    public void ShootInDirection(Vector3 position, Vector3 direction, float force)
    {
        transform.position = position + direction * 0.15f;
        circleCollider2D.enabled = true;
        rigidBody2D.gravityScale = 0.003f;
        rigidBody2D.AddForce(direction * force);
    }

    public void ReturnToBasket(Vector3 pos)
    {
        rigidBody2D.gravityScale = 0.00f;
        rigidBody2D.velocity = Vector2.zero;
        circleCollider2D.enabled = false;
        if(activeCoroutine == null)
            activeCoroutine = StartCoroutine(CollectBallPrivate(pos));
    }

    private IEnumerator CollectBallPrivate(Vector3 pos)
    {
        while (Vector3.Distance(transform.position, pos) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, pos, 10.0f * Time.deltaTime);
            yield return null;
        }
        transform.position = pos;
        gameObject.SetActive(false);
        OnBallCollected?.Invoke();
        yield return null;
    }
}
