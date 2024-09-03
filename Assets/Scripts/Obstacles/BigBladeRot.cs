using UnityEngine;

public class BigBladeRot : MonoBehaviour {

    public float rotSpeed;
    public Transform hitchPnt;

	void Update ()
    {
        if(PauseExit.timescale == false)
        {
            transform.RotateAround(hitchPnt.position, Vector3.up, rotSpeed * 60 / FPSCounter.forPlayer);
        }
	}
}
