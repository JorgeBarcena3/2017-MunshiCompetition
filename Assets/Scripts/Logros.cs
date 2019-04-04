using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Logros : MonoBehaviour {
        

    public static int [] HS = { 3,0,0,0};
    
	public Text [] puntuaciones;//Cuadros de texto donde poner las HS (High Score)

    public void colocarHS() {

        for (int i = 0; i < puntuaciones.Length; i++) puntuaciones[i].text = Convert.ToString(HS[i]);


    }
}
