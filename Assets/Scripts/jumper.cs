using UnityEngine;

public class jumper : MonoBehaviour
{
    public Transform[] player;
    private int modelNum;

	// Use this for initialization
	void Start ()
    {
        modelNum = PlayerPrefs.GetInt("CurrentModel", 0);
    }

    public void jumpda()
    {
        if (player[modelNum].position.y > -0.1 && player[modelNum].position.y <= 0)
        {
            if (modelNum == 0)
            {
                PlayerMovement.jumpda = true;
            }
            if (modelNum == 1)
            {
                PlayerMovement1.jumpda = true;
            }
            if (modelNum == 2)
            {
                PlayerMovement2.jumpda = true;
            }
        }
    }
}
