using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleSelectView : IUserView
{
    public RoleSelectView(IUserModel model, GameObject rootUI) : base(model, rootUI) { }

    Button but_start = null;
    public override void Initialize()
    {
        but_start = UnityTool.FindChildComponent<Button>(RootUI, "but_start");
        if (but_start != null)
        {
            but_start.onClick.AddListener(()=> 
            {
                SceneStateController.Instance.SetState(SceneType.MainSecene, typeof(MainSecene));
                SceneStateController.Instance.RemoveScene(SceneType.RoleSelectScene);
            });
        }
    }

    public override void Release()
    {
        but_start = null;
    }
}
