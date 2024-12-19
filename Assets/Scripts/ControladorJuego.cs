using UnityEngine;
using TMPro; // Librería para los Textos
public class ControladorJuego : MonoBehaviour
{
    // Textos de los marcadores
    [SerializeField] private TMP_Text marcadorPala1;
    [SerializeField] private TMP_Text marcadorPala2;
    // Componentes transform de las palas y la bola => para reiniciar posición
    [SerializeField] private Transform pala1Transform;
    [SerializeField] private Transform pala2Transform;
    [SerializeField] private Transform bolaTransform;
    // Variables que almacen el valor de las puntuaciones
    private int golesPala1, golesPala2;

    // Patrón Singleton para tener una única instancia
    private static ControladorJuego instance;
    public static ControladorJuego Instance
    {
        get
        {
            if(instance==null)
            {
                instance = FindFirstObjectByType<ControladorJuego>();
            }
            return instance;
        }
    }

    public global::System.Int32 GolesPala1 { get => golesPala1; set => golesPala1 = value; }
    public global::System.Int32 GolesPala2 { get => golesPala2; set => golesPala2 = value; }

    // Actualizamos los marcadores
    public void GolPala1()
    {
        GolesPala1++;
        marcadorPala1.text = GolesPala1.ToString();
    }
    public void GolPala2()
    {
        GolesPala2++;
        marcadorPala2.text = GolesPala2.ToString();
    }
    // Cuando se anota un punto / gol reinciamos posiciones de las palas y de la bola
    public void Reiniciar()
    {
        pala1Transform.position = new Vector2(pala1Transform.position.x, 0);
        pala2Transform.position = new Vector2(pala2Transform.position.x, 0);
        bolaTransform.position = new Vector2(0, 0);
    }
}