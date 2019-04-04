using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guardado : MonoBehaviour {

	private static int [] colores = { 0, 0, 0, 0 }; //Indica el numero de logros a conseguir, 0 si no se ha conseguido, 1 si esta conseguido.
	public static Image[] logros = new Image [4]; //Almacena el numero de logros de tipo true o false;
    public Image[] logros_inspector = new Image [4];

    void Start()
    {

        for (int i = 0; i < logros_inspector.Length; i++) //Determina las propiedades 
            logros[i] = logros_inspector[i];


    }


	public static void cargar() { //Carga datos de la partida almacenados con anterioridad gracias a la clase de unity PlayerPrefs

		Logros.HS[0] = PlayerPrefs.GetInt("HS1");
		Logros.HS[1] = PlayerPrefs.GetInt("HS2");
		Logros.HS[2] = PlayerPrefs.GetInt("HS3");
		Logros.HS[3] = PlayerPrefs.GetInt("HS4");
		colores[0] = PlayerPrefs.GetInt("color1");
		colores[1] = PlayerPrefs.GetInt("color2");
		colores[2] = PlayerPrefs.GetInt("color3");
		colores[3] = PlayerPrefs.GetInt("color4");
		colorearLogros(); //Si el logro está conseguido lo pinto de verde, sino lo dejo igual


	}

	private static void colorearLogros() { //

		for (int i = 0; i < colores.Length; i++)
		{

			if (colores[i] == 1) logros[i].color = Color.green; //Si esta conseguido se pinta de verde
			
		}


	}

	public static void comprobacionHS() { //Compara los High Scores con los ya almacenados, si el nuevo es mayor lo guardo.

		if (Script_controlador.numeroClicks > Logros.HS[0] && Script_controlador.TIEMPO == 10) Logros.HS[0] = Script_controlador.numeroClicks;
		else if (Script_controlador.numeroClicks > Logros.HS[1] && Script_controlador.TIEMPO == 20) Logros.HS[1] = Script_controlador.numeroClicks;
		else if (Script_controlador.numeroClicks > Logros.HS[2] && Script_controlador.TIEMPO == 30) Logros.HS[2] = Script_controlador.numeroClicks;
		else if (Script_controlador.numeroClicks > Logros.HS[3] && Script_controlador.TIEMPO == 60) Logros.HS[3] = Script_controlador.numeroClicks;


	}

	public static void comprobacionLogros()//Se comprueban los logros, si esta conseguido se cambian a verde, en caso contrario se quedan como estan
	{

		if (Script_controlador.numeroClicks > 160 && Script_controlador.TIEMPO == 10)
		{

			logros[0].color = Color.green;
			colores[0] = 1;

		}
		else if (Script_controlador.numeroClicks > 300 && Script_controlador.TIEMPO == 20)
		{

			logros[1].color = Color.green;
			colores[1] = 1;

		}
		else if (Script_controlador.numeroClicks > 450 && Script_controlador.TIEMPO == 30)
		{

			logros[2].color = Color.green;
			colores[2] = 1;

		}
		else if (Script_controlador.numeroClicks > 700 && Script_controlador.TIEMPO == 60)
		{

			logros[3].color = Color.green;
			colores[3] = 1;

		}


	}

	public static void reinicarEstadisticas() //Reinicia las estadisticas a 0
	{

		PlayerPrefs.SetInt("HS1", 0);
		PlayerPrefs.SetInt("HS2", 0);
		PlayerPrefs.SetInt("HS3", 0);
		PlayerPrefs.SetInt("HS6", 0);
		PlayerPrefs.SetInt("color1", 0);
		PlayerPrefs.SetInt("color2", 0);
		PlayerPrefs.SetInt("color3", 0);
		PlayerPrefs.SetInt("color4", 0);
		PlayerPrefs.Save();

	}

	public static void guardado() { //Guarda las estadisticas para futuras partidas

		PlayerPrefs.SetInt("HS1", Logros.HS[0]);
		PlayerPrefs.SetInt("HS2", Logros.HS[1]);
		PlayerPrefs.SetInt("HS3", Logros.HS[2]);
		PlayerPrefs.SetInt("HS6", Logros.HS[3]);
		PlayerPrefs.SetInt("color1", colores[0]);
		PlayerPrefs.SetInt("color2", colores[1]);
		PlayerPrefs.SetInt("color3", colores[2]);
		PlayerPrefs.SetInt("color4", colores[3]);
		PlayerPrefs.Save();

	}







}
