using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EndLevel : MonoBehaviour
{
    #region Unity Methods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Touch Goal");
        }

        //find out which segment they touched, the higher up the more  points
    }

    #endregion Unity Methods
}