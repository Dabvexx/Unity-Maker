using UnityEngine;

public class FreeCam : MonoBehaviour
{
    public Camera cam;
    public float moveSpeed = 10f;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Fixedupdate()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            transform.position += Input.GetAxis("Horizontal") * transform.right * Time.deltaTime * moveSpeed;
        }
    }
}
