using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsFinal : MonoBehaviour
{
    /*
    [Header("Physics2D.overlapBox")]
    public Vector2 boxPos;
    public Vector2 boxSize;
    public LayerMask mask;

    [Header("Physics2D.overlapCollider")]
    public Collider2D col;
    public ContactFilter2D filter;
    */
    [Header("State")]
    public bool isGrounded; 
    public bool wasGroundedLastFrame;
    public bool justGotGrounded;
    public bool justNotGrounded;
    public bool isFalling;

    public bool isCeiling;
    public bool wasCeilingLastFrame;
    public bool justGotCeiling;
    public bool justNotCeiling;

    public bool isTouchingWall;
    public bool wasTouchingWallLastFrame;
    public bool justGotTouchingWall;
    public bool justNotTouchingWall;


    [Header("Filter propierties")]
    public ContactFilter2D groundFilter;
    public int maxHits;

    [Header("Bottom Box")]
    public Vector2 groundBoxPos;
    public Vector2 groundBoxSize;

    [Header("Wall Box")]
    public Vector2 wallBoxPos;
    public Vector2 wallBoxSize;

    [Header("Top Box")]
    public Vector2 topBoxPos;
    public Vector2 topBoxSize;


    public void MyStart() 
    {
        ResetState();
    }

    void ResetState()
    {
        wasGroundedLastFrame = isGrounded;

        isGrounded = false;
        justGotGrounded = false;
        justNotGrounded = false;
        isFalling = true;

        isCeiling = false;
        wasCeilingLastFrame = false;
        justGotCeiling = false;
        justNotCeiling = false;

        isTouchingWall = false;
        wasTouchingWallLastFrame = false;
        justGotTouchingWall = false;
        justNotTouchingWall = false;
    }

    public void MyFixedUpdate()
    {
        ResetState();
        GroundDetection();
        WallDetection();
        CeilingDetection();
    }


    void GroundDetection ()
    {
        Collider2D[] results = new Collider2D[maxHits];
        Vector2 pos = this.transform.position;
        int numHits = Physics2D.OverlapBox(pos + groundBoxPos, groundBoxSize, 0, groundFilter, results);

        if(numHits > 0)
        {
            isGrounded = true;
        }

        if(isGrounded) isFalling = false;
        if(isGrounded && !wasGroundedLastFrame) justGotGrounded = true;
        if(!isGrounded && wasGroundedLastFrame) justNotGrounded = true;


    }

    void WallDetection()
    {
        Collider2D[] results = new Collider2D[maxHits];
        Vector2 wallPlayerPos = this.transform.position;
        int numHits = Physics2D.OverlapBox(wallPlayerPos + wallBoxPos, wallBoxSize, 0, groundFilter, results);

        if (numHits > 0)
        {
            isTouchingWall = true;
        }

      //  if (isTouchingWall) isFalling = false;
        if (isTouchingWall && !wasTouchingWallLastFrame) justGotTouchingWall = true;
        if (!isTouchingWall && wasTouchingWallLastFrame) justNotGrounded = true;

    }

    void CeilingDetection()
    {

        Collider2D[] results = new Collider2D[maxHits];
        Vector2 topPlayerPos = this.transform.position;
        int numHits = Physics2D.OverlapBox(topPlayerPos + topBoxPos, topBoxSize, 0, groundFilter, results);

        if (numHits > 0)
        {
            isCeiling = true;
        }

        //if (isCeiling) isFalling = true;
        if (isCeiling && !wasCeilingLastFrame) justGotCeiling = true;
        if (!isCeiling && wasCeilingLastFrame) justNotCeiling = true;

    }

    public void Flip(bool face)
    {
        if(face) wallBoxPos.x = Mathf.Abs(wallBoxPos.x);
        else wallBoxPos.x = -Mathf.Abs(wallBoxPos.x);
    }


    private void OnDrawGizmosSelected ()
    {
        Vector2 pos = this.transform.position;
        Gizmos.DrawWireCube(pos + groundBoxPos, groundBoxSize);

        Vector2 wallPos = this.transform.position;
        Gizmos.DrawWireCube(pos + wallBoxPos, wallBoxSize);

        Vector2 topPos = this.transform.position;
        Gizmos.DrawWireCube(pos + topBoxPos, topBoxSize);

    }
}
