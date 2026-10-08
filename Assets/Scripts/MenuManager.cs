using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        //Loads first level on click of the button
        SceneManager.LoadScene("LevelSelect");
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level1");
    }



    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

public void CharacterSelectScene()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

    /// <summary>
/// Stores the selected character index in PlayerPrefs bullshit
/// </summary>
    public void CharacterSelect(int characterIndex)
    {
        PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
        PlayerPrefs.Save();

         SceneManager.LoadScene("Menu");
        
    }

}
