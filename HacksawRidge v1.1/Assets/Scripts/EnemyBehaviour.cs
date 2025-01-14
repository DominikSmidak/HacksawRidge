using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform[] points;

    [SerializeField]
    private float moveSpeed = 2f;

    private Vector2 startingPosition;
    private int pointIndex = 0;
    private bool movingForward = true;
    private Vector2 lastPosition;
    public Animator anim;

    [SerializeField]
    private Transform viewColliderTransform;

    void Start()
    {
        startingPosition = transform.position;
        lastPosition = transform.position;
    }

    void Update()
    {
        Move();
        Animate();
        UpdateViewColliderRotation();
    }

    private void Move()
    {
        if (points.Length == 0) return;

        Vector2 targetPosition = startingPosition + (Vector2)points[pointIndex].localPosition;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.01f)
        {
            if (movingForward)
            {
                pointIndex++;
                if (pointIndex >= points.Length)
                {
                    pointIndex = points.Length - 2;
                    movingForward = false;
                }
            }
            else
            {
                pointIndex--;
                if (pointIndex < 0)
                {
                    pointIndex = 1;
                    movingForward = true;
                }
            }
        }
    }
    private void Animate()
    {
        Vector2 currentPosition = transform.position;
        Vector2 direction = currentPosition - lastPosition;

        anim.SetFloat("X", direction.x);
        anim.SetFloat("Y", direction.y);

        lastPosition = currentPosition;
    }

    private void UpdateViewColliderRotation()
    {
        if (movingForward)
        {
            viewColliderTransform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            viewColliderTransform.localRotation = Quaternion.Euler(0, 0, 180);
        }
    }
}
