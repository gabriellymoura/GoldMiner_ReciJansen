using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//função para fazer o controle da rotação do minerador com a arma
public class Gun : MonoBehaviour
{
    public GameObject claw;
    public bool isShooting; // se está atirando
    public Animator minerAnimator; 
    public Claw clawScript;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isShooting){ // verifica se o botão do mouse está pressionado
            LancaClaw();
        }
    }
    void LancaClaw(){
        isShooting = true;
        minerAnimator.speed = 0;
        RaycastHit hit;
        Vector3 down =  transform.TransformDirection(Vector3.down);
        if(Physics.Raycast(transform.position, down, out hit, 100)){
            claw.SetActive(true);
            clawScript.ClawTarget(hit.point);
        }
    }
    public void ColetaObjeto(){
        isShooting = false;
        minerAnimator.speed = 1;
    }
}
