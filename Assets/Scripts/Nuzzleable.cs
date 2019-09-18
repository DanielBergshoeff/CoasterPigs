using UnityEngine;

public class Nuzzleable : MonoBehaviour
{
    public Animator MyAnimator;

    public string TriggerName;
    
    public void TriggerAnimation()
    {
        MyAnimator.SetTrigger(TriggerName);
    }
}
