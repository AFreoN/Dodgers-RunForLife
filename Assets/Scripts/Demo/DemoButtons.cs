using UnityEngine.UI;
using UnityEngine;

public class DemoButtons : MonoBehaviour
{
    public Button left;
    public Button right;
    public Button jump;

    void Start ()
    {
        left.interactable = false;
        right.interactable = false;
        jump.interactable = false;
	}

}
