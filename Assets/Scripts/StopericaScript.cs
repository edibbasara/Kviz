using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopericaScript : MonoBehaviour {
   
    public Sprite jedan;
    public Sprite dva;
    public Sprite tri;
    public Sprite cetiri;
    public Sprite pet;
    public Sprite sest;
    public Sprite sedam;
    public Sprite osam;
    public Sprite devet;
    public Sprite deset;

    public float secondsCount = 0;
    public int brojacAudio =0;
    public static bool StopVrijeme = false;
    public AudioClip secundsClip;
    public AudioClip secundsClip1;
    // Update is called once per frame
    void Update()
    {        
         StartCoroutine(UpdateTimerUI(1));        
    }
    IEnumerator UpdateTimerUI(float d)
    {
        //set timer UI
        yield return new WaitForSeconds(d);
        
        if (StopVrijeme == false)
        {
            secondsCount += Time.deltaTime;

            
            if (secondsCount <= 11)
            {                
                if ((int)secondsCount == 1)
                {
                    if(brojacAudio == 0)
                    {
                        GetComponent<AudioSource>().PlayOneShot(secundsClip);
                        brojacAudio++;
                    }
                    transform.GetComponent<SpriteRenderer>().sprite = jedan;
                    
                }
                else if ((int)secondsCount == 2)
                {
                    if (brojacAudio == 1)
                    {
                        GetComponent<AudioSource>().PlayOneShot(secundsClip);
                        brojacAudio++;
                    }
                    transform.GetComponent<SpriteRenderer>().sprite = dva;
                }
                else if ((int)secondsCount == 3)
                {
                    if (brojacAudio == 2)
                    {
                        GetComponent<AudioSource>().PlayOneShot(secundsClip);
                        brojacAudio++;
                    }
                    transform.GetComponent<SpriteRenderer>().sprite = tri;
                    
                }
                else if ((int)secondsCount == 4)
                {
                    if (brojacAudio == 3)
                    {
                        GetComponent<AudioSource>().PlayOneShot(secundsClip);
                        brojacAudio++;
                    }
                    transform.GetComponent<SpriteRenderer>().sprite = cetiri;
                   
                }
                else if ((int)secondsCount == 5)
                {
                    if (brojacAudio == 4)
                    {
                        GetComponent<AudioSource>().PlayOneShot(secundsClip);                        
                        brojacAudio++;
                    }
                    transform.GetComponent<SpriteRenderer>().sprite = pet;
                   
                }
                else if ((int)secondsCount == 6)
                {
                    if (brojacAudio == 5)
                    {
                        GetComponent<AudioSource>().PlayOneShot(secundsClip);
                        brojacAudio++;
                    }
                    transform.GetComponent<SpriteRenderer>().sprite = sest;
                    
                }
                else if ((int)secondsCount == 7)
                {
                    if (brojacAudio == 6)
                    {
                        GetComponent<AudioSource>().PlayOneShot(secundsClip);
                        brojacAudio++;
                    }
                    transform.GetComponent<SpriteRenderer>().sprite = sedam;
                }
                else if ((int)secondsCount == 8)
                {
                    if (brojacAudio == 7)
                    {
                        GetComponent<AudioSource>().PlayOneShot(secundsClip);
                        brojacAudio++;
                    }
                    transform.GetComponent<SpriteRenderer>().sprite = osam;
                }
                else if ((int)secondsCount == 9)
                {
                    if (brojacAudio == 8)
                    {
                        GetComponent<AudioSource>().PlayOneShot(secundsClip1);
                        brojacAudio++;
                    }
                    transform.GetComponent<SpriteRenderer>().sprite = devet;
                }
                else if ((int)secondsCount == 10)
                {
                    if (brojacAudio == 9)
                    {
                        GetComponent<AudioSource>().PlayOneShot(secundsClip1);
                        brojacAudio=0;
                    }
                    transform.GetComponent<SpriteRenderer>().sprite = deset;
                    GameMenager.TrenutnaPitanja[TestPitanje.BrojPitanja - 1].IsPropusten = true;
                    GameMenager.bodoviDefault = 5;
                    StartCoroutine(NewScene(1f));                  

                }

            }
        }
       
    }

    private IEnumerator playSound(int v)
    {
        yield return new WaitForSeconds(v);
        GetComponent<AudioSource>().PlayOneShot(secundsClip);
    }

    IEnumerator NewScene(float d)
    {
        yield return new WaitForSeconds(d);
        SceneManager.LoadScene(1);
    }

}
