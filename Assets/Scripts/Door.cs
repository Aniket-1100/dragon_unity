using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        bool goRight = collision.transform.position.x < transform.position.x;
        cam.MoveToNewRoom(goRight ? nextRoom : previousRoom);
    }
}
