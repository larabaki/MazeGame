using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
public UnityEngine.UI.Button button;
public Text time;
public Text health;
public Text durum;
public float hiz=1.5f;
private Rigidbody rg;
float sayac=30;
int healtbar=3;
bool gameCont=true;
bool gameComp=false;

private void Update() {
  if(gameCont && !gameComp){
  sayac-=Time.deltaTime;
  time.text=(int)sayac + " ";
  }
  else if(!gameComp){
    durum.text="Oyunu Tamamlayamadın. :( ";
    button.gameObject.SetActive(true);
  }
  if(sayac<0){
    gameCont=false;
  }
}
    void Start()
    {
        rg=GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
      if(gameCont && !gameComp){
        float yatay=Input.GetAxis("Horizontal");
        float dikey= Input.GetAxis("Vertical");
        Vector3 kuvvet= new Vector3 (yatay,0,dikey);
        rg.AddForce(kuvvet*hiz);
      }
      else{
        rg.velocity=Vector3.zero;
        rg.angularVelocity=Vector3.zero; //Dönmesin diye
      }
      
    }
    void  OnCollisionEnter(Collision cls) {
      string objIsm=cls.gameObject.name;
      if(objIsm.Equals("FinishPoint"))  {
        gameComp=true;
        durum.text="Oyun Tamamlandı!Tebrikler ";
        button.gameObject.SetActive(true);
      }
      else if (!objIsm.Equals("MainPlane")&& !objIsm.Equals("MapPlane") ){
        healtbar-=1;
        health.text=healtbar+" ";  
      if(healtbar==0)
        gameCont=false;
       }

          }
}
