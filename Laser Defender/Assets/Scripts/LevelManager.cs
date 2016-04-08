using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public void LoadLevel(string name){
		Debug.Log("Level load requested for: "+name);
		//Brick.breakableCount = 0;
		SceneManager.LoadScene(name);
	}
	public void QuitRequest(){
		Application.Quit();
	}
	public void ReturnRequest(string name){
		SceneManager.LoadScene(name);
	}
	public void LoadNextLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	public void BrickDestroyed(){
		//if(Brick.breakableCount <= 0){
	//		LoadNextLevel();
	//	}
	}
}
