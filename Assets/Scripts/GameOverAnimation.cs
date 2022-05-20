using UnityEngine;

public class GameOverAnimation : MonoBehaviour
{
    public GameObject gameOverPanel;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ActivePanel()
    {
        gameOverPanel.SetActive(true);
    }
    public void AnimationOver()
    {
        animator.SetBool("isDead", false);
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
