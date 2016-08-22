using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class BotonJugar : MonoBehaviour {

	public string nombreEscenaParaCargar;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}

	void OnMouseDown(){
		Camera.main.GetComponent<AudioSource> ().Stop ();
		GetComponent<AudioSource> ().Play ();
		Invoke ("CargarNivelJuego", GetComponent<AudioSource>().clip.length);

	
	}

	void CargarNivelJuego(){

		SceneManager.LoadScene (nombreEscenaParaCargar);
	}
}
