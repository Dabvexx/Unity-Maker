using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{

    #region Variables
    public Camera curCam;
    private Transform playerTransform;

    public float offset = 1.85f;
	#endregion
	
	#region Unity Methods
    
    void Start()
    {
        curCam = GetComponent<Camera>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    
    void LateUpdate()
    {
        curCam.orthographicSize = 7f;

        Vector3 temp = transform.position;

        temp.x = playerTransform.position.x;

        temp.y = playerTransform.position.y;

        temp.y += offset;

        transform.position = temp;
    }
	
	#endregion
}
