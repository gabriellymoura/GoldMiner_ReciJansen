using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour{
    public Transform origin;
    public float speed = 4;
    public Gun gun;
    public Score score;
    //pontuação
    private Vector3 target; //alvo
    private int valorPneu = 100;
    private int valorComida  = 50;
    private int valorGarrafa  = 25;
    private GameObject childObject; // obj filho
    private LineRenderer lineRenderer; // desenha uma linha
    private bool abaterPneu;
    private bool abaterComida;
    private bool abaterGarrafa;
    private bool retracting;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, transform.position);

        if(transform.position == origin.position && retracting){
            gun.ColetaObjeto();
            if(abaterPneu){
                score.addPoints(valorPneu);
                abaterPneu = false;

            }else if (abaterComida){
                score.addPoints(valorComida);
                abaterComida = false;
            }else if (abaterGarrafa){
                score.addPoints(valorGarrafa);
                abaterGarrafa = false;
            }
            Destroy(childObject);
            gameObject.SetActive(false);
        }
    }
    public void ClawTarget (Vector3 pos){
        target = pos;
    }
    void OnTriggerEnter (Collider other){
        retracting = true;
        target = origin.position;

        if(other.gameObject.CompareTag("garrafa")){
            abaterGarrafa = true;
            childObject = other.gameObject;
            other.transform.SetParent(this.transform);
            GetComponent<AudioSource>().Play();
            StartCoroutine(Musica());
        }
        else if (other.gameObject.CompareTag("pneu")){
            abaterPneu = true;
            childObject = other.gameObject;
            other.transform.SetParent(this.transform);
            GetComponent<AudioSource>().Play();
            StartCoroutine(Musica());
        }
        else if (other.gameObject.CompareTag("comida")){
            abaterComida = true;
            childObject = other.gameObject;
            other.transform.SetParent(this.transform);
            GetComponent<AudioSource>().Play();
            StartCoroutine(Musica());
        }
    }
    public IEnumerator Musica(){
        yield return new WaitForSeconds(0.5f);
        GetComponent<AudioSource>().Stop();

    }
}
