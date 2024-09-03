using UnityEngine;
using UnityEngine.UI;

public class colorChanger : MonoBehaviour
{

	void Start ()
    {
        gameObject.GetComponent<Image>().color = new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256), 255);
	}
    private void OnEnable()
    {
        gameObject.GetComponent<Image>().color = new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256), 255);
    }
}
