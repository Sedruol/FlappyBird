using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float upForce = 350f;
    private Rigidbody2D rbPlayer;
    private Animator animatorPlayer;
    private bool isDead = false;
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        animatorPlayer = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            Flap();
        }
    }

    private void Flap()
    {
        rbPlayer.velocity = Vector2.zero;
        rbPlayer.AddForce(Vector2.up * upForce);
        animatorPlayer.SetTrigger("Flap");
    }

    private void OnCollisionEnter2D()
    {
        isDead = true;
        animatorPlayer.SetTrigger("Die");
        GameManager.Instance.GameOver();
    }
}