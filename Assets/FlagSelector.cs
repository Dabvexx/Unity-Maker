using UnityEngine;

public class FlagSelector : MonoBehaviour
{
    #region Variables

    public ButtonHandeler buttonHandeler;

    #endregion Variables

    #region Unity Methods

    private void Start()
    {
        buttonHandeler = GameObject.Find("GameManager").GetComponent<ButtonHandeler>();
    }

    private void OnMouseDown()
    {
        GameObject gmobj = this.gameObject;

        buttonHandeler.flagGen = gmobj.GetComponent<FlagGenerator>();
    }

    #endregion Unity Methods
}