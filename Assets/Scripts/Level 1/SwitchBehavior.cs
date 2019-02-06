using System.Collections.Generic;

public class SwitchBehavior : Item {

    public List<TurningPathBehavior> pathsInControl;

    private EyeBehavior eye;
    
    void Start () 
    {
        eye = GetComponentInChildren<EyeBehavior>();
	}

    public void SetEye (bool isOpened)
    {
        eye.SetEye(isOpened);
    }

    public override void Operate()
    {
        foreach (var path in pathsInControl)
        {
            path.ToggleTurnPath();
        }
    }
}
