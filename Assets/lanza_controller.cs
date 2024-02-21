using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanza_controller : MonoBehaviour
{
    
    Animator anim;
    
    bool lanzar = false;
    
    bool clavada = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        lanzar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // debug
            Debug.Log("lanzar");
            lanzar = true;
            anim.SetBool("lanzar", true);
            anim.SetTrigger("reforjando");
            
            if (lanzar == true)
            {
                lanzaNormal();

                // secuencia de valores por los que pasa la lanza al ser lanzada
                //StartCoroutine(esperarPostLanzar());

                //StartCoroutine(esperarPostClavada());
            }
            /*
            if (Input.GetKeyDown(KeyCode.Space))
            {
                clavada = false;
                anim.SetBool("clavada", false);
            }
            */
        }
        // secuencia natural de la lanza al ser lanzada
        void lanzaNormal()
        {
            // secuencia de valores por los que pasa la lanza al ser lanzada
            StartCoroutine(esperarPostLanzar());
            
            StartCoroutine(esperaSegundos(2));
            Debug.Log("postWait lanzar");
            if (clavada==true)
            {
                StartCoroutine(esperarPostClavada());
            }
            
        }
        IEnumerator esperarPostLanzar()
        {
            // esperar 2 segundos
            yield return new WaitForSeconds(2);

            lanzaClavar();
        }

        void lanzaClavar()
        {
            // la lanza es clavada
            lanzar = false;
            anim.SetBool("lanzar", false);
            
            clavada = true;
            anim.SetBool("clavada", true);
        }
        
        IEnumerator esperarPostClavada()
        {
            // esperar 2 segundos
            yield return new WaitForSeconds(2);

            clavadaIdle();
        }
        void clavadaIdle()
        {
            Debug.Log("clavadaIdle");
            clavada = false;
            anim.SetBool("clavada", false);
        }
        IEnumerator esperaSegundos(int segundos)
        {
            yield return new WaitForSeconds(segundos);
        }
    }
}
