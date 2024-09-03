using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ChangeButton : MonoBehaviour {

    public Sprite[] s1;
    public Button b1;
    public Button b2;

    private void Start()
    {
        b1.image.sprite = s1[0];
        b2.image.sprite = s1[1];
        b1.image.rectTransform.sizeDelta = new Vector2(411.4f, 113.7f);
        b2.image.rectTransform.sizeDelta = new Vector2(337.6f, 98.1f);
    }

    public void UpgradepanelBtn()
    {
        b1.image.sprite = s1[0];
        b2.image.sprite = s1[1];
        b1.image.rectTransform.sizeDelta = new Vector2(411.4f, 113.7f);
        b2.image.rectTransform.sizeDelta = new Vector2(337.6f, 98.1f);
    }
    public void CharacterpanelBtn()
    {
        b1.image.sprite = s1[1];
        b2.image.sprite = s1[0];
        b2.image.rectTransform.sizeDelta = new Vector2(411.4f, 113.7f);
        b1.image.rectTransform.sizeDelta = new Vector2(337.6f, 98.1f);
    }
}
