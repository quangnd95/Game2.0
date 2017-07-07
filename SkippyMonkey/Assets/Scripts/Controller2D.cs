﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    public LayerMask collideMaskObstacle;
    public LayerMask collideMaskBanana;
    public float skinWidth;

    private BoxCollider2D bc2D;
    private Bounds colliderBounds;
    private RaycastOrigins raycastOrigins;
    private PlayerStatus playerStatus;
    private void Awake()
    {
        bc2D = GetComponent<BoxCollider2D>();
    }

    public PlayerStatus Move(Vector2 velocity)
    {
        UpdateColliderBounds();

        //Ke tia ngang xet va cham
        Vector2 raycastOriginTop = velocity.x > 0 ? raycastOrigins.topRight : raycastOrigins.topLeft;   //Hướng kẻ
        Vector2 raycastOriginMiddle = velocity.x > 0 ? raycastOrigins.middleRight : raycastOrigins.middleLeft;
        Vector2 raycastOriginBottom = velocity.x > 0 ? raycastOrigins.bottomRight : raycastOrigins.bottomLeft;

        velocity = RaycastHorizontal(velocity, raycastOriginTop);
        velocity = RaycastHorizontal(velocity, raycastOriginMiddle);
        velocity = RaycastHorizontal(velocity, raycastOriginBottom);

        //Ke tia doc xet va cham
        Vector2 raycastOriginLeft = velocity.y > 0 ? raycastOrigins.topLeft : raycastOrigins.bottomLeft;
        Vector2 raycastOriginRight = velocity.y > 0 ? raycastOrigins.topRight : raycastOrigins.bottomRight;

        velocity = RaycastVertical(velocity, raycastOriginLeft);
        velocity = RaycastVertical(velocity, raycastOriginRight);

        playerStatus.velocity = velocity;
        return playerStatus;
    }

    private Vector2 RaycastHorizontal(Vector2 velocity, Vector2 raycastOrigin)
    {
        RaycastHit2D hit = Physics2D.Raycast(
            raycastOrigin,      //Điểm bắt đầu
            velocity.WithY(0),  //Phương kẻ
            Mathf.Abs(velocity.x) + skinWidth,  //Độ dài
            collideMaskObstacle //Nơi va chạm
        );
        
        if (hit)
        {
            if (velocity.x > 0)
                playerStatus.isCollidingRight = true;
            else
                playerStatus.isCollidingLeft = true;

            velocity.x = (hit.distance - skinWidth) * Mathf.Sign(velocity.x);
        }

        return velocity;
    }

    private Vector2 RaycastVertical(Vector2 velocity, Vector2 raycastOrigin)
    {
        RaycastHit2D hit = Physics2D.Raycast(
            raycastOrigin,
            velocity.WithX(0),
            Mathf.Abs(velocity.y) + skinWidth,
            collideMaskObstacle
        );
        if (hit)
        {
            if (velocity.y > 0)
            {
                playerStatus.isCollidingTop = true;
                velocity.y = (hit.distance - skinWidth) * Mathf.Sign(velocity.y);
            }
                
            else
            {
                playerStatus.isCollidingBottom = true;
                
            }
            velocity.y = 0;


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
        raycastOrigins.middleLeft = new Vector2(
            colliderBounds.min.x,
            colliderBounds.max.y/2
        );
        raycastOrigins.middleRight = new Vector2(
            colliderBounds.max.x,
            colliderBounds.max.y/2
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
    public Vector2 middleLeft;
    public Vector2 middleRight;
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