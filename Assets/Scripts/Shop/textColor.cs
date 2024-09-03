using UnityEngine;
using UnityEngine.UI;

public class textColor : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		gameObject.GetComponent<Text>().color = new Color32((byte)Random.Range(0, 256), 0, (byte)Random.Range(0, 256), 255);
    }
    private void OnEnable()
    {
        gameObject.GetComponent<Text>().color = new Color32((byte)Random.Range(0, 256), 0, (byte)Random.Range(0, 256), 255);
    }
}
