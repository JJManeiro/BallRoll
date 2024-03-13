using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anima : MonoBehaviour
{
    private Animator animator;
    private bool isJumping = false;
    private bool Grounded = true;
    private bool onIdle = true;
    private bool Blinking = false;
    public Transform enemy;
    private Renderer playerRenderer;
    private Color originalColor;
    public Color customColor = new Color(0.8f, 0.2f, 0.1f, 0.5f);
    public float detectionRadius = 8f;
    public float blinkSpeed = 5f;
    
    void Start()
    {
        //Invoca las animaciones de Idle y Jump
        animator = GetComponent<Animator>();
        //Renderiza el color rojo en la corrutina.
        playerRenderer = GetComponent<Renderer>();
        //Retorna del rojo al color principal que tenía el jugador.
        originalColor = playerRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        //Si el jugador no se mueve, la animación idle se activa.
        if (!(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))){
        animator.SetBool("onIdle", true);
        }
        //De lo contrario, la animación Idle se acaba.
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)){
            animator.SetBool("onIdle",false);
            animator.SetBool("Grounded",true);
        }
        if (Input.GetKeyDown(KeyCode.Space)&& Grounded){
            //Si salta occure lo siguiente: Se activa la animación jump, y el estado Saltando es true.
            //Si Saltando es true, En el suelo se vuelve false y se para la corrutina.
            animator.SetBool("isJumping",true);
            isJumping = true;
            animator.SetBool("Grounded",false);
            if (isJumping == true){
            Grounded = false;
            Blinking = false;
            StopBlinking();
            }
        }
        //Distancia entre el enemigo y el jugador.
        float distanceToEnemy = Vector3.Distance(transform.position, enemy.position);
        if (distanceToEnemy < detectionRadius && Blinking == false && Grounded == true)
        //Si esta es menor a X, EL jugador no parpadea y está en el suelo. Empieza la corrutina y parpadea.
        {
            StartBlinking();
        }
    }
    //Estos 2 voids arrancan y paran la corrutina
    void StartBlinking(){
        StartCoroutine(Blink());
    }
    void StopBlinking()
    {
        StopCoroutine(Blink());
    }
    //la dichosa corrutina que explicaré ahora.
    IEnumerator Blink()
    {
        //Parpadeo es falso por defecto. Este entrará ahora en un bucle donde se torna falso y verdadero.
        Blinking = true;
        // t es el tiempo que tardará
        float t = 0;
        while (t < 1)
        {
            t+= Time.deltaTime * blinkSpeed;
            //Este comando torna el color original del jugador en rojo
            playerRenderer.material.color = Color.Lerp(originalColor, customColor, t);
            yield return null;
        }
        //espera medio segundo.
        yield return new WaitForSeconds(0.5f);
        // acá se torna el parpadeo de verdadero a falso
        t = 0;
        while (t < 1)
        {
            t+= Time.deltaTime * blinkSpeed;
            //Acá se torna de rojo al color del jugador.
            playerRenderer.material.color = Color.Lerp(customColor, originalColor, t);
            yield return null;
        }
        Blinking = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        //Si el jugador toca el suelo, Salto se vuelve false y En el suelo se vuelve true. La animación del salto se para.
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Grounded",true);
            Grounded = true;
            animator.SetBool("isJumping",false);
        }
    }
}
