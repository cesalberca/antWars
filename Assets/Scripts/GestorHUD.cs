﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GestorHUD : MonoBehaviour {

    public Text salud;
    public Text materiales;
    public GameObject jugador;
    public GameObject baseOperaciones;

    public List<Button> almacenBotones;
    public Text textoMuerte;
    public Text textoBase;
    public Button reiniciar;
    public Button menu;

    private bool estadoBotones;
    private int vida;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        mostrarBotones();
        controlarMuerte();
        refrescar();
    }

    public void refrescar()
    {
        if(jugador!= null)
        {
            salud.text = "SALUD " + jugador.GetComponent<Jugador>().vida;
            materiales.text = "MATERIALES " + jugador.GetComponent<Jugador>().almacenMateriales;
        }
    }

    void mostrarBotones()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            controlarBotones();
        }
    }
    public void controlarBotones()
    {
        if (estadoBotones == true)
        {
            enableAlmacenBotones(false);
        } else if (estadoBotones == false)
        {
            enableAlmacenBotones(true);
        }
    }

    void enableAlmacenBotones(bool estado)
    {
        for (int i = 0; i < almacenBotones.Count; i++)
        {
            Debug.Log("hola" + i);
            almacenBotones[i].transform.gameObject.SetActive(estado);
            estadoBotones = estado;
        }
    }

    void controlarMuerte()
    {
        vida = jugador.GetComponent<Jugador>().vida;
        if (vida <= 0)
        {
            textoMuerte.transform.gameObject.SetActive(true);
            reiniciar.transform.gameObject.SetActive(true);
            menu.transform.gameObject.SetActive(true);
        }

        //aqui va un if que comprueba que la vida de la base es mayor que 0
    }

    public void irMenu()
    {
        SceneManager.LoadScene("menuPrincipal");
    }

    public void reiniciarMapa()
    {
        SceneManager.LoadScene("juegoPrincipal");
    }
}
