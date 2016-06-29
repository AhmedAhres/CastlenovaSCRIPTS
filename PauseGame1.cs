using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PauseGame1 : MonoBehaviour {
	public Transform canvas;





	// Update is called once per frame

	public void Pause(){
		if (canvas.gameObject.activeInHierarchy == false) {
			canvas.gameObject.SetActive (true);
			Time.timeScale = 0;

		} 
		else 
		{
			canvas.gameObject.SetActive(false);

			Time.timeScale = 1;
		
		}
	}


	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Pause ();
	
		}
}
	public void Restart(){
		Time.timeScale = 1;

		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	public void Quit(){
		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");
	}

}
