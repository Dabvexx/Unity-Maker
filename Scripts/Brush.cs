using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(SpriteRenderer))]
public class Brush : MonoBehaviour
{
    public TileBase tile;
    private Camera cam;
    public GameObject placer;
    public Tilemap tilemap;
    private float zAxis = 0f;
    private Vector3 mousePosition;
    private SpriteRenderer sr;
    public Sprite newSprite;

    public Texture2D cursor;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        cam = Camera.main;

        Cursor.visible = true;
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void LateUpdate()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = zAxis;
        placer.transform.position = mousePosition;

        //todo: figure out way to be able to switch out rule tile
        if (Input.GetMouseButton(1))
        {
            var tilePos = tilemap.WorldToCell(transform.position);
            tilemap.SetTile(tilePos, null);
        }

        if (Input.GetMouseButton(0))
        {
            var tilePos = tilemap.WorldToCell(transform.position);
            tilemap.SetTile(tilePos, tile);
        }
    }

    /*
    private void moveTool()
    {
        //find out way to set the tile to the current tile
        sr.sprite = newSprite;
    }
    */
}