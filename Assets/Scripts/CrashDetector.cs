using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1f; // Delay before reloading the scene
    [SerializeField] ParticleSystem deathEffect; // Particle effect to play when the player dies

    void OnTriggerEnter2D(Collider2D other)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");
        if (other.gameObject.layer == layerIndex)
        {
            deathEffect.Play();
            Invoke(nameof(ReloadScene), reloadDelay);
        }

    
    }
     void ReloadScene()
        {
            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
}
