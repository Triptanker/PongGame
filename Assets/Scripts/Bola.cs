using UnityEngine;

public class Bola : MonoBehaviour
{
    // Establecemos una velocidad inicial y valorDeMultplicacion
    [SerializeField] private float velocidadInicial = 4f;
    [SerializeField] private float valorDeMultiplicacion = 1.1f;
    
    // Cogemos referencia a su RigidBody
    private Rigidbody2D bolaRb;

    void Start()
    {
        bolaRb = GetComponent<Rigidbody2D>();
        Lanzar();
    }
    // Método que se encarga de lanzar la bola en el comienzo
    private void Lanzar ()
    {
        float velocidadX = Random.Range(0,2) == 0 ? 1 : -1; // Range nos da 0 o 1 y lo convertimos a 1 o -1
        float velocidadY = Random.Range(0,2) == 0 ? 1 : -1; // Asignamos a la velocidad de la bola un Vector2 y la multiplicamos por esa velocidad inicial
        bolaRb.linearVelocity = new Vector2(velocidadX, velocidadY) * velocidadInicial;
    }
    
    // Método para saber cuando se produce una colisión
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Verificamos si colisiona con un objeto con TAG "Pala" => aumentamos velocidad
        if(collision.gameObject.CompareTag("Pala"))
            bolaRb.linearVelocity *= valorDeMultiplicacion;
    }  

    // Detectamos si se alcanzó alguna de las 2 zonas de gol
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("GolPala2"))
        {
            ControladorJuego.Instance.GolPala1();
        }
        else
        {
            ControladorJuego.Instance.GolPala2();
        }
        // Reiniciamos los elementos del juego y lanzamos la bola
        ControladorJuego.Instance.Reiniciar();
        Lanzar();
    }
}
