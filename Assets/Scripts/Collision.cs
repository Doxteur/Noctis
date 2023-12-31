﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    [Header("Layers")]
    public LayerMask groundLayer;

    [Space]

    public bool onGround;
    public bool onWall;
    public bool onRightWall;
    public bool onLeftWall;
    public int wallSide;
    public bool aboutToLeaveWall;


    [Space]

    [Header("Collision")]

    public float collisionRadius = 0.25f;
    public Vector2 bottomOffset, rightOffset, leftOffset, rightcliffCheckerOffset, leftcliffCheckerOffset, bottomWidth;
    private Color debugCollisionColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        // use collisionRadius but add the bottomWidth for the size
        //onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius + bottomWidth.x, groundLayer);
        onGround = Physics2D.OverlapCapsule((Vector2)transform.position + bottomOffset, bottomWidth, CapsuleDirection2D.Vertical, 0, groundLayer);
        onWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer) 
            || Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer);

        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer);
        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer);

        aboutToLeaveWall = !Physics2D.OverlapCircle((Vector2)transform.position + rightcliffCheckerOffset, collisionRadius, groundLayer)
            && !Physics2D.OverlapCircle((Vector2)transform.position + leftcliffCheckerOffset, collisionRadius, groundLayer);

        wallSide = onRightWall ? -1 : 1;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { bottomOffset, rightOffset, leftOffset, rightcliffCheckerOffset, leftcliffCheckerOffset };

        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightcliffCheckerOffset, collisionRadius);
        // Draw OverlapCapsule
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftcliffCheckerOffset, collisionRadius);
    }
}
