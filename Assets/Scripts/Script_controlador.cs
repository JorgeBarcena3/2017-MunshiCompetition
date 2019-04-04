using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Script_controlador : MonoBehaviour {

	public static int TIEMPO = 10; //Determina el tiempo de juego
    public static int numeroClicks = 0; //Contador de clicks realizados por el jugador
    public Text NumerodeclicksTexto, tiempo, puntuacionfinal, apoyo_t;
    private float time = 10;
    private char textoTiempo; //Cuadro de texto 
    public GameObject ventanaPuntuacion, juego;
    private Boolean cuenta_atras;
    public string[] apoyo = {//Frases para animar al jugador

        "Glop, glop, glop...",
        "GUAU",
        "Sigue Asi!",
        "Como me gusta esto!",
        "Venga, un poco mas rápido",
        "Vas a batir un record",
        "Dame mas fuerte, cariño",
        "Eso es lo mas rápido que puedes?",
        "Que decepción!",
        "Lastima que seas tan lento",
        "Eres mas rápido que Usain Bolt!",
        "Me haces daño!",
        "Me das verguenza!",
        "Tengo miedo...",
        "...",
        "Que quieres que te diga",
        "BUBUCELAAAAAH"

    };

    Boolean semaforo_apoyo = true;
    Boolean modo_extremo = false;

    public void modoExtremoEstado() {

        if (modo_extremo == false)
            modo_extremo = true;
        else
            modo_extremo = false;


        Debug.Log(modo_extremo);
    }




    void Start () {


        Guardado.cargar(); //Cargo los datos de la partida anterior

        
        time = TIEMPO;//Se asigna al tiempo, un tiempo por defecto
        cuenta_atras = false;

	}

    public GameObject Bicho_pulsador;

    private void cambioPosicion()
    {

        float tamañornd = UnityEngine.Random.Range(0.5f, 2.5f);
        Bicho_pulsador.transform.localScale = new Vector3(tamañornd, tamañornd, tamañornd);
        float posicionXRnd = UnityEngine.Random.Range(-65, 80);
        float posicionYRnd = UnityEngine.Random.Range(56, -19);
        Bicho_pulsador.transform.localPosition = new Vector3(posicionXRnd,posicionYRnd,Bicho_pulsador.transform.position.z);


    }


    public void posicionOriginal() {


        if (modo_extremo == false) {


            Bicho_pulsador.transform.localPosition = new Vector3(1.4f, 2.7f, Bicho_pulsador.transform.position.z);
            Bicho_pulsador.transform.localScale = new Vector3(3.298483f, 3.298483f, 3.298483f);


        }


    }

	void Update () { 


        if (Input.GetKey(KeyCode.Escape)) {//Se se presiona el boton esc, o en caso de movil el boton de atras, se sale de la aplicacion

            Guardado.guardado(); //Guarda los datos obtenidos para utiliarlos con anterioridad
            Application.Quit();

        }


        if (numeroClicks % 5 == 4) //Controla que se pueda entrar al bucle para cambiar las frases de apoyo
            semaforo_apoyo = true;


        if (semaforo_apoyo == true && numeroClicks % 5 == 0 && numeroClicks != 0 ) { //Cambia aleatoriamente las frases de aopoyo al jugador

            NumerodeclicksTexto.fontSize = 40;
            apoyo_t.text = apoyo[UnityEngine.Random.Range(0, apoyo.Length)];

            semaforo_apoyo = false;

        } else NumerodeclicksTexto.fontSize = 30;


        if (time > 0 && cuenta_atras == true)//Determina cuando el contador de tiempo debe avanzar y cuando no.
        {

            time -= Time.deltaTime;

            tiempo.text = "Tiempo: " + time.ToString("f0");
            NumerodeclicksTexto.text = Convert.ToString(numeroClicks);

        }

        else if(time < 0 && cuenta_atras == true) { //En caso de que la partida haya terminado, se cambia de ventana, y la cuantaatras se convierte en falsa. Se compureban las HS

            ventanaFinal();
            cuenta_atras = false;
			Guardado.comprobacionHS();
            Guardado.comprobacionLogros();
			

        }

        puntuacionfinal.text = Convert.ToString(numeroClicks);//Pinto el numero de puntuacion en la pantalla


    }

  

    public void permitirCuenta() {//Permite que el contador de tiempo comience
		
        cuenta_atras = true;

    }

    public void cambio(int _tiempo) {//Cambia la variable principal que lleva el tiempo

        TIEMPO = _tiempo;

    }

    public void inicializacion() { //Inicializa los valores por defecto


        time = TIEMPO;
        numeroClicks = 0;


}
    public void ventanaFinal() {//Cambia a la ventana final

        juego.SetActive(false);
        ventanaPuntuacion.SetActive(true);


    }

    public void clik(){//Aumenta +1 la puntuacion

        numeroClicks++;
        if (modo_extremo == true)
            cambioPosicion();

    }

    public void twitter() {//Lleva a mi twitter, como desarollador

        Application.OpenURL("https://twitter.com/Jorge_barcena3");
    }
    
}
