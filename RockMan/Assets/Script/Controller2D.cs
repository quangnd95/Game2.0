﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    public LayerMask collideMask;
    public float skinWidth;

    private BoxCollider2D bc2D;
    private Bounds colliderBounds;
    private RaycastOrigins raycastOrigins;


    private void Awake()
    {
        bc2D = GetComponent<BoxCollider2D>();
    }

    public PlayerStatus Move(Vector2 velocity)
    {
        UpdateColliderBounds();

        velocity = RaycastHorizontal(velocity);
        velocity = RaycastVertical(velocity);
        //return velocity;
        return new PlayerStatus
        {
            velocity = velocity
        };
    }

    private Vector2 RaycastHorizontal(Vector2 velocity)
    {
        Vector2 raycastOriginTop = velocity.x > 0 ? raycastOrigins.topRight : raycastOrigins.topLeft;
        Vector2 raycastOriginBottom = velocity.x > 0 ? raycastOrigins.bottomRight : raycastOrigins.bottomLeft;

        RaycastHit2D hitTop = Physics2D.Raycast(
            raycastOriginTop,
            velocity.WithY(0),
            Mathf.Abs(velocity.x) + skinWidth,
            collideMask
        );

        if (hitTop)
        {
            velocity.x = (hitTop.distance - skinWidth) * Mathf.Sign(velocity.x);
        }

        RaycastHit2D hitBottom = Physics2D.Raycast(
            raycastOriginBottom,
            velocity.WithY(0),
            Mathf.Abs(velocity.x) + skinWidth,
            collideMask
        );

        if (hitBottom)
        {
            velocity.x = (hitBottom.distance - skinWidth) * Mathf.Sign(velocity.x);
        }

        return velocity;
    }

    private Vector2 RaycastVertical(Vector2 velocity)
    {
        Vector2 raycastOriginLeft = velocity.y > 0 ? raycastOrigins.topLeft : raycastOrigins.bottomLeft;
        Vector2 raycastOriginRight = velocity.y > 0 ? raycastOrigins.topRight : raycastOrigins.bottomRight;

        RaycastHit2D hitLeft = Physics2D.Raycast(
            raycastOriginLeft,
            velocity.WithX(0),
            Mathf.Abs(velocity.y) + skinWidth,
            collideMask
        );

        if (hitLeft)
        {
            velocity.y = (hitLeft.distance - skinWidth) * Mathf.Sign(velocity.y);
        }

        RaycastHit2D hitRight = Physics2D.Raycast(
            raycastOriginRight,
            velocity.WithX(0),
            Mathf.Abs(velocity.y) + skinWidth,
            collideMask
        );

        if (hitRight)
        {
            velocity.y = (hitRight.distance - skinWidth) * Mathf.Sign(velocity.y);
        }

        return velocity;
    }

    private void UpdateColliderBounds()
    {
        colliderBounds = bc2D.bounds;
        colliderBounds.Expand(-skinWidth * 2);
        UpdateRaycastOrigins();
    }

    private void UpdateRaycastOrigins()
    {
        raycastOrigins.topLeft = new Vector2(
            colliderBounds.min.x,
            colliderBounds.max.y
        );
        raycastOrigins.topRight = new Vector2(
            colliderBounds.max.x,
            colliderBounds.max.y
        );
        raycastOrigins.bottomLeft = new Vector2(
            colliderBounds.min.x,
            colliderBounds.min.y
        );
        raycastOrigins.bottomRight = new Vector2(
            colliderBounds.max.x,
            colliderBounds.min.y
        );
    }
}

struct RaycastOrigins
{
    public Vector2 topLeft;
    public Vector2 topRight;
    public Vector2 bottomLeft;
    public Vector2 bottomRight;
}

public struct PlayerStatus
{
    public Vector2 velocity;
    public bool isCollidingTop;
    public bool isCollidingRight;
    public bool isCollidingBottom;
    public bool isCollidingLeft;
}