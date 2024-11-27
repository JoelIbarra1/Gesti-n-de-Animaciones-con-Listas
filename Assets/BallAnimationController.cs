using UnityEngine;

public class BallAnimationController : MonoBehaviour
{
    public Animator animator; // El componente Animator de la pelota
    private string[] animations = { "Move", "jump", "rotate" }; // Lista de animaciones
    private int currentAnimationIndex = 0; // �ndice de la animaci�n actual

    void Start()
    {
        // Verificar que el Animator est� asignado
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        // Cambiar animaci�n con flechas
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeAnimation(1); // Avanzar en la lista
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeAnimation(-1); // Retroceder en la lista
        }

        // Reproducir la animaci�n actual con espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayAnimation();
        }
    }

    // Cambia el �ndice de la animaci�n
    void ChangeAnimation(int direction)
    {
        currentAnimationIndex = (currentAnimationIndex + direction + animations.Length) % animations.Length;
        Debug.Log("Animaci�n seleccionada: " + animations[currentAnimationIndex]);
    }

    // Reproduce la animaci�n seleccionada
    void PlayAnimation()
    {
        string animationToPlay = animations[currentAnimationIndex];
        animator.Play(animationToPlay);
        Debug.Log("Reproduciendo: " + animationToPlay);
    }
}
