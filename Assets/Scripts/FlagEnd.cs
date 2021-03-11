using UnityEngine;

public class FlagEnd : EndLevel
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Touch Goal");
        }

        //find out which segment they touched, the higher up the more  points
    }
}