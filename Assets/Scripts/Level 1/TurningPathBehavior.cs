using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurningPathBehavior : MonoBehaviour {

    private Animator animator;

    public List<SwitchBehavior> controlledBy;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

	public void ToggleTurnPath()
    {
        animator.SetBool("isPathTurned", !animator.GetBool("isPathTurned"));
    }

    public bool IsPathTurned()
    {
        return animator.GetBool("isPathTurned");
    }

    public void OnTurnEnd()
    {
        TurnEdgeAlign();
    }

    public void OnTurnStart()
    {
        RefreshEyeStatus();
    }

    private void RefreshEyeStatus()
    {
        foreach (var eyeSwitch in controlledBy)
        {
            Debug.Log("set Turned" + IsPathTurned());
            eyeSwitch.SetEye(IsPathTurned());
        }
    }

    private void TurnEdgeAlign()
    {
        // Align to ~90~
        var degree = transform.eulerAngles.y;
        var main = (int) (degree / 10);
        var little = degree % 10;
        var after = (little < 5) ?  main * 10 : (main + 1) * 10;

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, after, transform.eulerAngles.z);
    }
}
