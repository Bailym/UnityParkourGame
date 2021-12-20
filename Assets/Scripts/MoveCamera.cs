using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public Transform player;

    //Just follows the player around.
    void Update() {
        transform.position = player.transform.position;
    }
}
