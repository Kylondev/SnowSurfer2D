using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    void Start()
    {
        //Gets the highest unlocked level from player prefs
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        //Gets layout group with all the level buttons
        Transform levels = transform.GetChild(0);

        for (int i = 0; i < levels.childCount; i++)
        {
            Button levelButton = levels.GetChild(i).GetComponent<Button>();
            levelButton.interactable = (i < unlockedLevel);
        }
    }
}
