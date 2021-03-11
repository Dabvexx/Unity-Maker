using UnityEngine;

public class EditorCam : MonoBehaviour
{
    public Camera curCam;
    public float scrollRate = 0.25f;

    // Start is called before the first frame update
    private void Start()
    {
        curCam = GetComponent<Camera>();
    }

    private void OnEnable()
    {
        curCam.orthographicSize = 10f;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        float xAxisValue = Input.GetAxis("Horizontal");
        float yAxisValue = Input.GetAxis("Vertical");
        float scroll = Input.GetAxis("zoom");
        if (Camera.current != null)
        {
            transform.Translate(new Vector3(xAxisValue * scrollRate * Time.deltaTime * 100, yAxisValue * scrollRate * Time.deltaTime * 100, 0.0f));
            curCam.orthographicSize += .15f * scroll;

            /*
            if (scrollWheel > 0)
            {
                //Upwards
                Camera.current.orthographicSize += scrollWheel * .15f;
            }
            else if (scrollWheel < 0)
            {
                //Downwards
                Camera.current.orthographicSize += scrollWheel * .15f;
            }
            */
        }

        if (curCam != null && curCam.orthographicSize <= 3)
        {
            curCam.orthographicSize = 3f;
        }

        if (curCam != null && curCam.orthographicSize >= 15)
        {
            curCam.orthographicSize = 15f;
        }

        /*
        float RampUp()
        {
            //make the camera croll faster after going in one direction for a second
            return 10f;
        }
        */
    }
}