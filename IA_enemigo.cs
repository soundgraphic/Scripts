using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_enemigo : MonoBehaviour
{
	public Transform tanque;
	public DisparoEnemigo disparoEnemigo;
	
	[HideInInspector]
	public bool stop;

	Vector3 direction;

	float rotSpeed = 5f;
	float chaseSpeed = 5f;

	float tiempoDisparo = 2f;
	float proximoDisparo;

    void Update()
	{
        if (stop)
			return;

        else
        {
			Cazar();
			
			if (Vector3.Distance(tanque.position, this.transform.position) < 20) // distancia a la cual dispara
			{
				Invoke("Disparar", 1f);
			}
		}
	}

	private void Cazar()
    {
		direction = tanque.position - this.transform.position;

		if (Vector3.Distance(tanque.position, this.transform.position) < 50) 
		{
			this.transform.rotation = 
				Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);

			if (Vector3.Distance(tanque.position, this.transform.position) > 5) 
			{
				this.transform.Translate(0, 0, chaseSpeed * Time.deltaTime);
			}
		}
	}

	private void Disparar()
    {
		if (Time.time > proximoDisparo)
		{
			proximoDisparo = Time.time + tiempoDisparo;
			disparoEnemigo.Disparo();
		}
	}

	public void DetenerCaza()
    {
		stop = true;
		Invoke("ReiniciarCaza", 3f);
    }

	void ReiniciarCaza()
    {
		stop = false;
    }
}
