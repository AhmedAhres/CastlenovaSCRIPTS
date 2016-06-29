using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public GameObject canvasMain;
	public GameObject canvasControl;


	public void MainMenu(){
		canvasMain.SetActive(true);
		canvasControl.SetActive(false);
	}

	public void Controls(){
		canvasMain.SetActive(false);
		canvasControl.SetActive(true);
	}

	public void Story1(){
		SceneManager.LoadScene("Story1");
	}
		

	public void Level1(){
		SceneManager.LoadScene("Level1");
	}
		

	public void LoadMenu(){
		SceneManager.LoadScene("MainMenu");
	}

    public void Quit(){
        Application.Quit();
    }
}
