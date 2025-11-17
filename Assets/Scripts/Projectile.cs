using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed = 7f;
    [SerializeField] private float maxLifetime = 5f;

    // Tags that stop the projectile
    [SerializeField] private string[] stopTags = { "Enemy", "Wall", "Ground" };

    private float direction;
    private bool hit;
    private float lifetime;

    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        lifetime = 0;
        hit = false;
        boxCollider.enabled = true;
    }

    private void Update()
    {
        if (hit) return;

        // Move
        transform.Translate(speed * direction * Time.deltaTime, 0, 0);

        // Auto disable after lifetime
        lifetime += Time.deltaTime;
        if (lifetime > maxLifetime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hit) return;

        // Ignore player completely
        if (other.CompareTag("Player"))
            return;

        // Check valid stop tags
        foreach (string tag in stopTags)
        {
            if (other.CompareTag(tag))
            {
                Hit();
                return;
            }
        }

        // If you want projectile to stop on ANY collider
        // uncomment below (otherwise ONLY stopTags stop it)
        //
         Hit();
    }

    private void Hit()
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");
    }

    public void SetDirection(float _direction)
    {
        direction = _direction;

        // Flip to direction
        Vector3 s = transform.localScale;
        if (Mathf.Sign(s.x) != _direction)
            s.x = -s.x;
        transform.localScale = s;

        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;
    }

    // Called from animation event
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
