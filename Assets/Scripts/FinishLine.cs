using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1f; // Delay before reloading the scene
    [SerializeField] ParticleSystem finishEffect; // Particle effect to play when the player reaches the finish line

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has reached the finish line!");
            finishEffect.Play(); // Play the particle effect

           

            // Goes to next level and saves the highest unlocked level number
            Invoke(nameof(NextLevel), reloadDelay);
        }
    }

    void NextLevel()
    {
         int unlockedLevel = PlayerPrefs.GetInt("unlockedLevel", 1);
        PlayerPrefs.SetInt("unlockedLevel", unlockedLevel + 1);
        PlayerPrefs.Save();
        if (unlockedLevel >= 4)
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
           SceneManager.LoadScene(($"Level{unlockedLevel++}")); 
        }
        
        
    }


}
