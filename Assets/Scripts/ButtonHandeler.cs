using UnityEngine;
using UnityEngine.UI;

public class ButtonHandeler : MonoBehaviour
{
    #region Variables

    [SerializeField]
    protected Button btn1;

    [SerializeField]
    protected Button btn2;

    public FlagGenerator flagGen;

    #endregion Variables

    #region Unity Methods

    private void Update()
    {
        btn1 = GameObject.Find("FlagUp").GetComponent<Button>();
        btn2 = GameObject.Find("FlagDown").GetComponent<Button>();

        btn1.onClick.RemoveAllListeners();
        btn2.onClick.RemoveAllListeners();

        btn1.onClick.AddListener(flagGen.IncreaseSize);
        btn2.onClick.AddListener(flagGen.DecreaseSize);
    }

    #endregion Unity Methods
}