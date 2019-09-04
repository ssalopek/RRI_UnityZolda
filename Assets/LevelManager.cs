using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public string nameScene;
	
    public void LoadLevel()
    {
        SceneManager.LoadScene(nameScene);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            LoadLevel();
        }
    }

    public void QuitLevel()
    {
        Application.Quit();
    }


}
