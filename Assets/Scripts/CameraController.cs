using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Room Camera")]
    [SerializeField] private float smoothTime = 0.25f;
    private float targetPosX;
    private Vector3 velocity = Vector3.zero;

    [Header("Player Follow")]
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance = 2f;
    [SerializeField] private float aheadSpeed = 4f;
    private float lookAhead;

    private bool followPlayer = true;

    private void Update()
    {
        if (!followPlayer)
        {
            // Move toward target room x
            Vector3 target = new Vector3(targetPosX, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothTime);
            return;
        }

        // Follow player
        lookAhead = Mathf.Lerp(lookAhead, aheadDistance * Mathf.Sign(player.localScale.x), Time.deltaTime * aheadSpeed);
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
    }

    public void MoveToNewRoom(Transform newRoom)
    {
        followPlayer = false;
        targetPosX = newRoom.position.x;

        // Restart following after reaching room
        Invoke(nameof(EnablePlayerFollow), 0.5f);
    }

    private void EnablePlayerFollow()
    {
        followPlayer = true;
    }
}
