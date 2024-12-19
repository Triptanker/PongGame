using UnityEngine;

public class Pala : MonoBehaviour
{
    // Indicamos [SerializeField] para poder verlo desde el inspector de Unity
    [SerializeField] private float velocidad = 7f;
    
    // Update se llama una vez cada frame
    void Update()
    {
        float movimiento;
        if (this.name == "Pala1")
            movimiento = Input.GetAxisRaw("VerticalPala1");
        else
        {
            movimiento = Input.GetAxisRaw("VerticalPala2");
        }

        float posY = transform.position.y + (movimiento * velocidad * Time.deltaTime);
        if (posY >= 3.5f || posY <= -3.5f)
            return;
        transform.position = new Vector3(transform.position.x, posY, 0);
    }
}
