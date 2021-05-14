using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionView : IUserView
{
    public TransitionView(IUserModel model, GameObject rootUI) : base(model, rootUI) { }

    //ui组件
    Image tags = null;
    Slider schedule = null;

    public override void Initialize()
    {
        tags = UnityTool.FindChildGameObject(RootUI, "img_tags").GetComponent<Image>();
        schedule = UnityTool.FindChildGameObject(RootUI, "Slid_schedule").GetComponent<Slider>();
    }

    public void Progress(float progress)
    {
        if (schedule != null)
        {
            schedule.value = progress;
        }
    }

    public void SetSprite(Sprite sprite)
    {
        tags.sprite = sprite;
    }


    public override void Show()
    {
        base.Show();
        schedule.value = 0;
    }
    public override void Release()
    {
        tags = null;
        schedule = null;
    }
}
