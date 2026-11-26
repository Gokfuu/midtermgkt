using UnityEngine;
using UnityEngine.InputSystem;

public class EvilWizard : MonoBehaviour
{
    public Animator animController;

    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            GetAttack();
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            GetHeavyAttack();
        }
    }

    public void GetAttack()
    {
        animController.SetTrigger("Attack");
    }

    public void GetHeavyAttack()
    {
        animController.SetTrigger("HeavyAttack");
    }
}