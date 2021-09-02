using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagGenerator : MonoBehaviour
{
    #region Variables

    public int height = 5;

    public GameObject flagSections;
    public GameObject flagTopper;
    public BoxCollider2D bc;

    protected GameObject pole;
    protected GameObject topper;

    public List<GameObject> Segments = new List<GameObject>();

    // end of flagpole variables

    public ButtonHandeler buttonHandeler;

    #endregion Variables

    #region Unity Methods

    private void Awake()
    {
        buttonHandeler = GameObject.Find("GameManager").GetComponent<ButtonHandeler>();

        if (Segments.Count == 0)
        {
            GenerateFlag(height);
        }
    }

    #endregion Unity Methods

    #region Methods

    private void GenerateFlag(int length)
    {
        topper = Instantiate(flagTopper, new Vector3(0, 0, 0), Quaternion.identity, this.transform);
        topper.transform.localPosition = new Vector3(0, Segments.Count + 1, 0);
        topper.name = "FlagTopper";
        Segments.Add(topper);

        for (int i = 1; i <= length - 1; i++)
        {
            IncreaseSize();
        }
    }

    public void DecreaseSize()
    {
        if (Segments.Count != 1)
        {
            pole = Segments[Segments.Count - 2];
            Segments.RemoveAt(Segments.Count - 2);

            Destroy(pole);

            topper.transform.localPosition = new Vector3(0, Segments.Count, 0);
        }

        RegenerateCollider();

        Debug.Log($"Size Decreased to {Segments.Count}");

    }

    public void IncreaseSize()
    {
        pole = Instantiate(flagSections, new Vector3(0, 0, 0), Quaternion.identity, this.transform);
        pole.transform.localPosition = new Vector3(0, Segments.Count, 0);
        pole.name = $"FlagPole_{Segments.Count}"; // raname segments so they arnt just FlagPole(clone)

        Segments.Insert(Segments.Count - 1, pole);

        Segments[Segments.Count - 1].transform.localPosition = new Vector3(0, Segments.Count, 0);

        RegenerateCollider();

        Debug.Log($"Size Increased to {Segments.Count}");
    }

    private void RegenerateCollider()
    {
        Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);
        bool hasBounds = false;
        SpriteRenderer[] renderers = { Segments[0].GetComponent<SpriteRenderer>(), topper.GetComponent<SpriteRenderer>() };

        foreach (Renderer render in renderers)
        {
            if (hasBounds)
            {
                bounds.Encapsulate(render.bounds);
            }
            else
            {
                bounds = render.bounds;
                hasBounds = true;
            }
        }

        if (hasBounds)
        {
            bc.offset = bounds.center - transform.root.position;
            bc.offset += new Vector2(0f, .4f);
            bc.size = new Vector2(.25f, bounds.size.y + .8f);
        }
        else
        {
            bc.size = bc.offset = Vector3.zero;
            bc.size = Vector3.zero;
        }
    }

    private void OnMouseDown()
    {
        buttonHandeler.flagGen = this;
    }

    #endregion Methods
}