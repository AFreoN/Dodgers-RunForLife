using UnityEngine;

public class CharView : MonoBehaviour {
    public Transform[] player;
    public Collider[] col;
    float startTime, endTime;
    Vector2 startPos, endPos;
    public float maxswipeTime;
    public float minswipeDis;
    public float rotSpeed;
    int modelNum;

	void Start ()
    {
        modelNum = PlayerPrefs.GetInt("CurrentModel", 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.touchCount == 1)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (col[modelNum].Raycast(ray,out hit,1000))
            {
                Debug.Log("Pressed");
                Touch touch = Input.GetTouch(0);
                if(touch.phase == TouchPhase.Began)
                {
                    startTime = Time.time;
                }
                else if(touch.phase == TouchPhase.Moved)
                {
                    Debug.Log("moved");
                    endPos = touch.position;
                    endTime = Time.time;
                    float swipeTime = endTime - startTime;
                    float swipeDis = (endPos - startPos).magnitude;
                    if(swipeDis > minswipeDis && swipeTime < maxswipeTime)
                    {
                        Debug.Log("in");
                        Vector2 distance = endPos - startPos;
                        if (distance.x > 0)
                        {
                            player[modelNum].Rotate(Vector3.up * -rotSpeed);
                        }
                        else if (distance.x < 0)
                        {
                            player[modelNum].Rotate(Vector3.up * rotSpeed);
                        }
                    }
                }
                else if(touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    transform.Rotate(Vector3.zero);
                }
                touch = Input.touches[Input.touches.Length - 1];
                startPos = touch.position;
            }
        }
    }
}