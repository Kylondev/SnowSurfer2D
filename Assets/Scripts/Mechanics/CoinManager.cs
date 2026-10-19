using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] ParticleSystem coinParticle;
    PlayerController playerController;
    SpriteRenderer coinSpriteRenderer;

    private void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        coinSpriteRenderer = GetComponentInChildren<SpriteRenderer>();

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && coinSpriteRenderer.enabled)
        {
            coinSpriteRenderer.enabled = false;
            playerController.coinSpeed();
            coinParticle.Play();
        }
    }

}
