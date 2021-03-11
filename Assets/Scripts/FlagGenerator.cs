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
    public BoxCollider2D boxCollider2D;

    protected GameObject pole;
    protected GameObject topper;

    public List<GameObject> Segments = new List<GameObject>();

    // end of flagpole variables

    public Button button;

    #endregion Variables

    #region Unity Methods

    private void Awake()
    {
        if (Segments.Count == 0)
        {
            GenerateFlag(height);
        }

        foreach (var section in Segments)
        {
            Debug.Log(section);
        }

        //Button btn = button.GetComponent<Button>();
        //btn.onClick.AddListener(IncreaseSize);
    }

    private void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            IncreaseSize();
        }

        if (Input.GetKeyDown("c"))
        {
            DecreaseSize();
        }
    }

    #endregion Unity Methods

    #region Methods

    private void GenerateFlag(int length)
    {
        topper = Instantiate(flagTopper, new Vector3(0, 0, 0), Quaternion.identity, flagBase.transform);
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
    }

    public void IncreaseSize()
    {
        pole = Instantiate(flagSections, new Vector3(0, 0, 0), Quaternion.identity, flagBase.transform);
        pole.transform.localPosition = new Vector3(0, Segments.Count, 0);
        pole.name = $"FlagPole_{Segments.Count}"; // raname segments so they arnt just FlagPole(clone)

        Segments.Insert(Segments.Count - 1, pole);

        Segments[Segments.Count - 1].transform.localPosition = new Vector3(0, Segments.Count, 0);

        RegenerateCollider();
    }

    private void RegenerateCollider()
    {
        //really it only needs 1 box collider that just gets its position moved up and its size increased by 1 each time

        //use bounds of all segments except the topper, calculate the size of a box collider
        //Bounds bounds;
    }

    #endregion Methods
}