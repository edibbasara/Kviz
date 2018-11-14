using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public class TestPitanje : MonoBehaviour
{
    public Text Pit;
    public Text Odg1;
    public Text Odg2;
    public Text Odg3;
    public Text Odg4;
    public Color getColour;
    public static int BrojPitanja;
    public static Pitanje PostaviPitanje;
    public Text PopUp;
    public GameObject PopUpPanel;
    public AudioClip OnClick;
    public AudioClip IsOK;
    public AudioClip IsFalse;

    void Start()
    {
        UcitajPitanje();
    }
    void Update()
    {
        UpdateTimerUI();
    } 
    
    public void UcitajPitanje()
    {
        PostaviPitanje = GameMenager.TrenutnaPitanja[BrojPitanja-1];
        Pit.text = PostaviPitanje.pitanje;
        Odg1.text = PostaviPitanje.odg[0].odg;
        Odg2.text = PostaviPitanje.odg[1].odg;
        Odg3.text = PostaviPitanje.odg[2].odg;
        Odg4.text = PostaviPitanje.odg[3].odg;

        GameMenager.PitanjeBr = BrojPitanja;
        if (PostaviPitanje.IsOdgovoren || PostaviPitanje.IsPropusten)
        {
            GameObject[] o = GameObject.FindGameObjectsWithTag("Odgovori");
            foreach (GameObject s in o)
            {
                s.transform.GetComponent<Button>().enabled = false;
                PopUpPanel.SetActive(true);
                PopUp.text = "PITANJE JE ODGOVORENO !!!";
                PopUp.color = Color.red;
                PopUp.enabled = true;
            }                         
        }
        
    }

    private void UpdateTimerUI()
    {
        GameMenager.secondsCount += Time.deltaTime;
        if(GameMenager.secondsCount > 60)
        {
            GameMenager.minuteCount++;
            GameMenager.secondsCount = 0;
        }
    }

    public void NextScene(int id)
    {
        StopericaScript.StopVrijeme = true;
        
        StartCoroutine(ProvjeriOdgovor(2,id));
        StartCoroutine(NovoPitanje(2));
    }

    IEnumerator NovoPitanje(float d)
    {
        yield return new WaitForSeconds(d);
        StopericaScript.StopVrijeme = false;
        SceneManager.LoadScene(1);
    }

    public void NazadPonisti()
    {
        GameMenager.TrenutnaPitanja[BrojPitanja - 1].IsPropusten = true;
        GetComponent<AudioSource>().PlayOneShot(OnClick);
        SceneManager.LoadScene(1);
    }

    IEnumerator ProvjeriOdgovor(float d,int id)
    {
        for (int i = 0; i < GameMenager.TrenutnaPitanja.Count; i++)
        {
            if (GameMenager.TrenutnaPitanja[i] == PostaviPitanje)
            {
                if (GameMenager.TrenutnaPitanja[i].odg[id].isTrue)
                {
                    GameMenager.TrenutnaPitanja[i].IsTacanOdg = true;
                    GameMenager.TrenutnaPitanja[i].IsOdgovoren = true;
                    PopUpPanel.SetActive(true);
                    PopUp.text = "ODGOVOR JE TAČAN !!!";
                    GameMenager.bodoviDefault *= 2;
                    GameMenager.rezultat += GameMenager.bodoviDefault;
                    PopUp.enabled = true;
                    GetComponent<AudioSource>().PlayOneShot(IsOK);
                    PopUp.color = Color.green;
                    if(id==0)
                    {
                        Odg1.color = Color.green;
                    }else if(id==1)
                    {
                        Odg2.color = Color.green;
                    }else if(id == 2)
                    {
                        Odg3.color = Color.green;
                    }else if(id == 3)
                    {
                        Odg4.color = Color.green;
                    }

                }
                else
                {
                    Debug.Log("NIJE TACAN !!!");
                    GameMenager.bodoviDefault = 5;
                    GameMenager.TrenutnaPitanja[i].IsOdgovoren = true;
                    PopUpPanel.SetActive(true);
                    PopUp.text = "ODGOVOR NIJE TAČAN !!!";                    
                    PopUp.enabled = true;
                    PopUp.color = Color.red;
                    GetComponent<AudioSource>().PlayOneShot(IsFalse);

                    for (int x = 0; x < 4; x++)
                    {
                        if (PostaviPitanje.odg[x].isTrue)
                        {
                            if (x == 0)
                            {
                                Odg1.color = Color.green;
                            }
                            else if (x == 1)
                            {
                                Odg2.color = Color.green;
                            }
                            else if (x == 2)
                            {
                                Odg3.color = Color.green;
                            }
                            else if (x == 3)
                            {
                                Odg4.color = Color.green;
                            }
                        }
                    }
                    if (id == 0)
                    {
                        Odg1.color = Color.red;
                    }
                    else if (id == 1)
                    {
                        Odg2.color = Color.red;
                    }
                    else if (id == 2)
                    {
                        Odg3.color = Color.red;
                    }else if(id == 3)
                    {
                        Odg4.color = Color.red;
                    }                    
                }
                
            }
        }

       
        yield return new WaitForSeconds(d);
        PopUp.enabled = false;
        PopUpPanel.SetActive(false);
    }
  

}