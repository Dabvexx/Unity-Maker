using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagGenerator : MonoBehaviour
{
    #region Variables

    public int height = 5;

    public GameObject flagSections;
    public GameObject flagTopper;
    public GameObject flagBase;
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
        // Change this to an event, the flag is currently dependant on this file existing.
        buttonHandeler = GameObject.Find("GameManager").GetComponent<ButtonHandeler>();
        
        // Dont generate flag if the flag already exists.
        if (Segments.Count == 0)
        {
            GenerateFlag(height);
        }
    }
    
    private void OnMouseDown()
    {
        // TODO: This really needs a rework with events.
        buttonHandeler.flagGen = this;
    }

    #endregion Unity Methods

    #region Methods

    private void GenerateFlag(int length)
    {
        // Add the flag topper as the first element in list.
        topper = Instantiate(flagTopper, new Vector3(0, 0, 0), Quaternion.identity, flagBase.transform);
        topper.transform.localPosition = new Vector3(0, Segments.Count + 1, 0);
        topper.name = "FlagTopper";
        Segments.Add(topper);

        // Generate flag up to base height.
        for (int i = 1; i <= length - 1; i++)
        {
            IncreaseSize();
        }
    }

    public void DecreaseSize()
    {
        // If the flag has more than one segment, decrease the height.
        if (Segments.Count = 1)
        {
            return;
        }
        
        // Subtreact by two to get the segment below the top of the flag.
        pole = Segments[Segments.Count - 2];
        Segments.RemoveAt(Segments.Count - 2);

        Destroy(pole);
            
        // Adjust flag height accordingly.
        topper.transform.localPosition = new Vector3(0, Segments.Count, 0);
        
        // After removing old segment, adjust collider accordingly.
        RegenerateCollider();

        Debug.Log($"Size Decreased to {Segments.Count}");

    }

    public void IncreaseSize()
    {
        // Create the new flagpole segment, then insert into the list.
        pole = Instantiate(flagSections, new Vector3(0, 0, 0), Quaternion.identity, flagBase.transform);
        pole.transform.localPosition = new Vector3(0, Segments.Count, 0);
        pole.name = $"FlagPole_{Segments.Count}"; // raname segments so they arnt just FlagPole(clone)

        Segments.Insert(Segments.Count - 1, pole);

        // Adjust flag height accordingly.
        Segments[Segments.Count - 1].transform.localPosition = new Vector3(0, Segments.Count, 0);

        // After adding a new segment, adjust collider accordingly.
        RegenerateCollider();

        Debug.Log($"Size Increased to {Segments.Count}");

    }

    private void RegenerateCollider()
    {
        // Black magic to regenerate the collider to encapsulate the whole flag instead of every segment having a seperate collider and script.
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

    #endregion Methods
}
