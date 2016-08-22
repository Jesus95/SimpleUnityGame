using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour {

	public int puntuacion=0;
	public TextMesh marcador;

	// Use this for initialization
	void Start () {

		NotificationCenter.DefaultCenter ().AddObserver (this, "IncrementarPuntos");
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeHaMuerto");
		ActualizarMarcador ();
	
	}

	void PersonajeHaMuerto(Notification notificacion){
	
		if (puntuacion > EstadoJuego.estadoJuego.puntuacionMaxima) {
			
			EstadoJuego.estadoJuego.puntuacionMaxima = puntuacion;
			EstadoJuego.estadoJuego.Guardar ();
		}
		else 
		{

			
		}
	
	}

	void IncrementarPuntos(Notification notificacion){
	
		int puntosAIncrementar = (int)notificacion.data;
		puntuacion+=puntosAIncrementar;
		ActualizarMarcador ();
	}

	void ActualizarMarcador()
	{
		marcador.text = puntuacion.ToString ();
	
	}

	// Update is called once per frame
	void Update () {
	
	}
}
