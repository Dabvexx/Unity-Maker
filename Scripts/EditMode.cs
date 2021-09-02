using UnityEngine;

public class EditMode : MonoBehaviour
{
    #region Variables

    public bool IsEditMode = true;
    private float camScale;

    public Camera cam;
    public GameObject player;
    public GameObject brush;
    public GameObject cursor;

    #endregion Variables

    #region Unity Methods

    private void Start()
    {
        cam = Camera.main;
        player = GameObject.Find("Player");
        brush = GameObject.Find("Brush");
    }

    private void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            IsEditMode = !IsEditMode;
        }

        if (IsEditMode)
        {
            cam.GetComponent<EditorCam>().enabled = true;
            cam.GetComponent<CameraFollow2D>().enabled = false;
            //brush.GetComponent<Brush>().enabled = true;
            player.GetComponent<Player>().enabled = false;
            player.GetComponent<Controller2D>().enabled = false;
        }

        if (!IsEditMode)
        {
            cam.GetComponent<EditorCam>().enabled = false;
            cam.GetComponent<CameraFollow2D>().enabled = true;
            brush.GetComponent<Brush>().enabled = false;
            player.GetComponent<Player>().enabled = true;
            player.GetComponent<Controller2D>().enabled = true;
        }
    }

    #endregion Unity Methods
}