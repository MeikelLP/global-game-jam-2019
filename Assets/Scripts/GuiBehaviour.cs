using UnityEngine;
using UnityEngine.UI;

public class GuiBehaviour : MonoBehaviour
{
    public Text text;
    public GameObject shopParent;

    public void ShowText(string txt = null)
    {
        if (string.IsNullOrWhiteSpace(txt))
        {
            text.transform.parent.gameObject.SetActive(false);
            text.text = "";
        }
        else
        {
            text.transform.parent.gameObject.SetActive(true);
            text.text = txt;
        }
    }

    private void Start()
    {
        shopParent.SetActive(false);
    }
}