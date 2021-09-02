using UnityEngine;
using UnityEngine.UI;

public class ButtonHandeler : MonoBehaviour
{
    #region Variables

    [SerializeField]
    protected Button flagBtn1;

    [SerializeField]
    protected Button flagBtn2;

    [SerializeField]
    protected GameObject panel;

    [SerializeField]
    protected Text text;

    public FlagGenerator flagGen;

    // Brush button variables
    public Sprite[] brushSprites;

    public bool toggle = true;

    public GameObject brush;
    public Button brushBtn;
    public Image img;
    #endregion Variables

    #region Unity Methods
    private void Awake()
    {
        flagBtn1 = GameObject.Find("FlagUp").GetComponent<Button>();
        flagBtn2 = GameObject.Find("FlagDown").GetComponent<Button>();

        brush = GameObject.Find("Brush");
        brushBtn = GameObject.Find("BrushButton").GetComponent<Button>();
        img = GameObject.Find("BrushButton").GetComponent<Image>();

        brushBtn.onClick.AddListener(BrushHandler);
    }

    private void Update()
    {
        FlagHeightHandler();
    }

    #endregion Unity Methods

    #region Methods
    public void FlagHeightHandler()
    {
        text.text = "Flag Height";

        flagBtn1.onClick.RemoveAllListeners();
        flagBtn2.onClick.RemoveAllListeners();

        flagBtn1.onClick.AddListener(flagGen.IncreaseSize);
        flagBtn2.onClick.AddListener(flagGen.DecreaseSize);
    }

    public void BrushHandler ()
    {
        toggle = !toggle;

        if (toggle)
        {
            img.sprite = brushSprites[1];
            brush.GetComponent<Brush>().enabled = true;
        }
        else
        {
            img.sprite = brushSprites[0];
            brush.GetComponent<Brush>().enabled = false;
        }
    }
    #endregion Methods
}