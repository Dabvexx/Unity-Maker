using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();

            Debug.Log("Quit Game");
        }
    }

    private void Awake()
    {
        // Put code that will reset the player to levels default position
    }
}
