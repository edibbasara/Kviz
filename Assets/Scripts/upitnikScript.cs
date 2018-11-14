using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upitnikScript : MonoBehaviour {
    public Sprite UpitMouseOver;
    public Sprite UpitMouseOut;
    public Sprite UsklikMouseOver;
    public Sprite UsklikMouseOut;
    public Sprite CheckMouseOver;
    public Sprite CheckMouseOut;
    public Sprite ErrorMouseOver;
    public Sprite ErrorMouseOut;

    public float Brzina = 10;
    public Cvor KrajnjaPozicija;
    public int PitanjeBroj;

  

    void Update() {
        if (transform.position != KrajnjaPozicija.transform.position && GameMenager.IsUpitnikStart == true)
        {
            Idi();
        }
        else if (transform.position == KrajnjaPozicija.transform.position)
        {
            GameMenager.IsUpitnikStart = false;
        }else if(GameMenager.IsUpitnikStart == false)
        {
            PonovoUcitaj();
        }
    }
    
    public void Idi()
    {
        float step = Brzina * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, KrajnjaPozicija.transform.position, step);
    }

    public void PonovoUcitaj()
    {
        transform.position = KrajnjaPozicija.transform.position;
        OnMouseOver();
        OnMouseExit();
    }

    private void OnMouseOver()
    {

        if (GameMenager.TrenutnaPitanja[PitanjeBroj - 1].IsOdgovoren == false)
        {
            transform.GetComponent<SpriteRenderer>().sprite = UpitMouseOver;
            if(GameMenager.TrenutnaPitanja[PitanjeBroj - 1].IsPropusten == true)
            {
                transform.GetComponent<SpriteRenderer>().sprite = UsklikMouseOver;
            }
        }else if (GameMenager.TrenutnaPitanja[PitanjeBroj - 1].IsOdgovoren == true)
        {
            if (GameMenager.TrenutnaPitanja[PitanjeBroj - 1].IsTacanOdg == true)
            {
                transform.GetComponent<SpriteRenderer>().sprite = CheckMouseOver;
            }
            else if (GameMenager.TrenutnaPitanja[PitanjeBroj - 1].IsTacanOdg == false)
            {
                transform.GetComponent<SpriteRenderer>().sprite = ErrorMouseOver;
            }
           
        }
    }
       
    
    public void OnMouseExit()
    {
        if (GameMenager.TrenutnaPitanja[PitanjeBroj - 1].IsOdgovoren == false)
        {
            transform.GetComponent<SpriteRenderer>().sprite = UpitMouseOut;
            if (GameMenager.TrenutnaPitanja[PitanjeBroj - 1].IsPropusten == true)
            {
                transform.GetComponent<SpriteRenderer>().sprite = UsklikMouseOut;
            }
        }
        else if(GameMenager.TrenutnaPitanja[PitanjeBroj - 1].IsOdgovoren == true)
        {
            if (GameMenager.TrenutnaPitanja[PitanjeBroj - 1].IsTacanOdg == false)
            {
                transform.GetComponent<SpriteRenderer>().sprite = ErrorMouseOut;
            } else if (GameMenager.TrenutnaPitanja[PitanjeBroj - 1].IsTacanOdg == true)
            {
                transform.GetComponent<SpriteRenderer>().sprite = CheckMouseOut;
            }
            else if(GameMenager.TrenutnaPitanja[PitanjeBroj - 1].IsPropusten == true)
            {
                transform.GetComponent<SpriteRenderer>().sprite = UsklikMouseOut;
            }
        }
    }
}
