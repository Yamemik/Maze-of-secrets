using UnityEngine;

public class Door : MonoBehaviour
{
    bool isOpened;

    [SerializeField] Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Open()
    {
        animator.SetBool("isOpened",isOpened);
        isOpened = !isOpened;
    }
}
