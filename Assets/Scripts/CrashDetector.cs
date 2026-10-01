using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
void OnTriggerEnter2D(Collider2D other)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");
        if (other.gameObject.layer == layerIndex)
        {
            Debug.Log("Player has crashed!");
            // Reloads the scene after1 second
            Invoke(nameof(ReloadScene), 1f);
        }

        void ReloadScene()
        {
            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
