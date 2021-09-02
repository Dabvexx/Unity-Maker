using UnityEngine;
using System.Collections;

public class FlagEnd : EndLevel
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Touch flag");
        }
        //find out which segment they touched, the higher up the more  points

        FindIntersect();
    }

    private void FindIntersect()
    {
        updateRayCastOrigins();
        CalculateRaySpacing();

        GameObject flag = transform.parent.gameObject.transform.GetChild(1).GetChild(1).gameObject;
        IEnumerator coroutine = MoveFlag(flag);

        //shoot ray upwards and find where it intersects with the players hitbox

        float rayLength = GetComponent<BoxCollider2D>().size.y;

        Vector2 rayOrigin = raycastOrigins.bottomLeft;
        rayOrigin.y -= skinWidth;
        rayOrigin.x -= skinWidth;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up, rayLength, collisionMask);

        Debug.DrawRay(rayOrigin, Vector2.up * rayLength, Color.red);

        if (hit)
        {
            Debug.Log("hit");

            StartCoroutine(coroutine);
            FindIndex(hit);
            return;
        }

        rayOrigin = raycastOrigins.bottomRight;
        rayOrigin.y -= skinWidth;
        rayOrigin.x += skinWidth;
        hit = Physics2D.Raycast(rayOrigin, Vector2.up, rayLength, collisionMask);

        Debug.DrawRay(rayOrigin, Vector2.up * rayLength, Color.red);

        if (hit)
        {
            Debug.Log("hit");

            StartCoroutine(coroutine);
            FindIndex(hit);
            return;
        }
    }

    private IEnumerator MoveFlag(GameObject flag)
    {
        while (flag.transform.position.y >= 0.8)
        {
            flag.transform.position += Vector3.down * .1f;

            yield return new WaitForEndOfFrame();
        }
        yield break;
    }

    private void FindIndex(RaycastHit2D hit)
    {
        int distance = (int)(hit.fraction * 100);
        int index;

        if (hit.fraction >= 92)
        {
            index = 6;
        }
        else
        {
            index = 0;
        }

        //Find index with height on flag
        PointHandler.CalculatePointsGained(index);
        return;
    }
}