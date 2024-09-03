using UnityEngine;

public class DemoJumper : MonoBehaviour
{
    public Transform player;

    public void jumpda()
    {
        if (player.position.y > -0.1 && player.position.y <= 0)
        {
            PlayerMovement2.jumpda = true;
        }
    }
}
