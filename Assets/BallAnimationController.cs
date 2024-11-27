using UnityEngine;

public class BallAnimationController : MonoBehaviour
{
    public Animator animator; // El componente Animator de la pelota
    private string[] animations = { "Move", "jump", "rotate" }; // Lista de animaciones
    private int currentAnimationIndex = 0; // Índice de la animación actual

    void Start()
    {
        // Verificar que el Animator está asignado
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        // Cambiar animación con flechas
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeAnimation(1); // Avanzar en la lista
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeAnimation(-1); // Retroceder en la lista
        }

        // Reproducir la animación actual con espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayAnimation();
        }
    }

    // Cambia el índice de la animación
    void ChangeAnimation(int direction)
    {
        currentAnimationIndex = (currentAnimationIndex + direction + animations.Length) % animations.Length;
        Debug.Log("Animación seleccionada: " + animations[currentAnimationIndex]);
    }

    // Reproduce la animación seleccionada
    void PlayAnimation()
    {
        string animationToPlay = animations[currentAnimationIndex];
        animator.Play(animationToPlay);
        Debug.Log("Reproduciendo: " + animationToPlay);
    }
}
