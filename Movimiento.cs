using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public static Movimiento instance;
    float movimiento;
    float rotacion;
    public float velMovimiento;
    public float velRotacion;
    bool muerto = false;

    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if (!muerto)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                Rotacion();
            }

            if (Input.GetAxis("Vertical") != 0)
            {
                Traslacion();
            }
        }
    }
    void Rotacion()
    {
        rotacion = Input.GetAxis("Horizontal") * velRotacion * Time.deltaTime;
        transform.Rotate(0, rotacion, 0);
        //FindObjectOfType<AudioManager>().Play("Torreta");
    }

    void Traslacion()
    {
        movimiento = Input.GetAxis("Vertical") * velMovimiento * Time.deltaTime;
        transform.Translate(0, 0, movimiento);
    }

    public void Muerto()
    {
        muerto = true;
    }
}
