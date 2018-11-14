using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {
    public static bool IsMatematika = false;
    public static bool IsPriroda = false;
    public static bool IsInformatika = false;

    public AudioClip OnClick;

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextScenes(int id)
    {
      GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(OnClick);
        SceneManager.LoadScene(id);
    }
    public void setProperty(int p)
    {
        if(p == 0)
        {
            IsMatematika = true;
        }else if(p==1)
        {
            IsPriroda = true;
        }else if(p == 2)
        {
            IsInformatika = true;
        }
    }
    public void NazadOpcija()
    {
        GameMenager.IsStartGame = true;
        IsMatematika = false;
        IsPriroda = false;
        IsInformatika = false;
        foreach(Pitanje p in GameMenager.TrenutnaPitanja)
        {
            p.IsOdgovoren = false;
            p.IsPropusten = false;
            p.IsTacanOdg = false;
        }
        GameMenager.IsUpitnikStart = true;
        GameMenager.bodoviDefault = 5;
        GameMenager.rezultat = 0;
        GameMenager.secondsCount = 0;
        GameMenager.minuteCount = 0;
    }

    public void Quit()
    {
        GetComponent<AudioSource>().PlayOneShot(OnClick);
        Application.Quit();
    } 
    public void OtpionsNE()
    {
        GetComponent<AudioSource>().PlayOneShot(OnClick);
    }

}
