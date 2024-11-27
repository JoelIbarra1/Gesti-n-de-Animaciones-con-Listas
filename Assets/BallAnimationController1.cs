using UnityEngine;

public class BallAnimationController1 : MonoBehaviour
{
    public Animator animator; // Componente Animator
    private string[] animations = { "Move", "jump", "rotate" }; // Lista de animaciones
    private int currentAnimationIndex = 0; // Índice actual de la animación
    private bool isAnimationChanging = false; // Controla si se está cambiando de animación
    private bool isPaused = false; // Controla si la animación está pausada

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // Comenzar con la primera animación
        PlayAnimation(currentAnimationIndex);
    }

    void Update()
    {
        // Pausar/reanudar con la barra espaciadora
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePause();
        }

        // Cambiar animación con flechas
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isAnimationChanging)
        {
            ChangeAnimation(1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !isAnimationChanging)
        {
            ChangeAnimation(-1);
        }
    }

    void TogglePause()
    {
        if (isPaused)
        {
            animator.speed = 1; // Reanudar
        }
        else
        {
            animator.speed = 0; // Pausar
        }
        isPaused = !isPaused;
    }

    void ChangeAnimation(int direction)
    {
        // Cambiar el índice de animación
        int nextAnimationIndex = (currentAnimationIndex + direction + animations.Length) % animations.Length;

        if (nextAnimationIndex != currentAnimationIndex) // Solo cambiar si es diferente
        {
            isAnimationChanging = true;
            StartCoroutine(WaitForAnimationToEnd(nextAnimationIndex));
        }
    }

    void PlayAnimation(int index)
    {
        animator.Play(animations[index]);
        currentAnimationIndex = index;
        Debug.Log("Reproduciendo: " + animations[index]);
    }

    System.Collections.IEnumerator WaitForAnimationToEnd(int nextAnimationIndex)
    {
        // Esperar hasta que termine la animación actual
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Reproducir la siguiente animación
        PlayAnimation(nextAnimationIndex);
        isAnimationChanging = false;
    }
}
