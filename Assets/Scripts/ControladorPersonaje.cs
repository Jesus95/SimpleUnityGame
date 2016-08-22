using UnityEngine;
using System.Collections;

public class ControladorPersonaje : MonoBehaviour {

	public float fuerzaSalto=100f;

	private bool enSuelo=true;
	public Transform comprobadorSuelo;
	float comprobadorRadio=0.07f;
	public LayerMask mascaraSuelo;

	private bool dobleSalto=false;
	private Animator animator;

	private bool corriendo=false;
	public float velocidad=1f;

	void Awake(){
	
		animator = GetComponent<Animator> ();
	
	}



	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate()
	{
		if (corriendo) 
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocidad, GetComponent<Rigidbody2D> ().velocity.y);

		}
		animator.SetFloat ("VelX", GetComponent<Rigidbody2D> ().velocity.x);
		enSuelo = Physics2D.OverlapCircle (comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
		animator.SetBool ("isGrounded", enSuelo);
		if (enSuelo) {
			dobleSalto = false;
		
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			if (corriendo) 
			{
				if ((enSuelo || !dobleSalto)) 
				{
					GetComponent<AudioSource> ().Play ();
					GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, fuerzaSalto);

					if(!dobleSalto && !enSuelo)
					{
						dobleSalto = true;

					}
				
				}
			
			} 
			else 
			{
			
				corriendo = true;
				NotificationCenter.DefaultCenter ().PostNotification (this,"PersonajeEmpiezaACorrer");
			}

		}
	
	}
}
