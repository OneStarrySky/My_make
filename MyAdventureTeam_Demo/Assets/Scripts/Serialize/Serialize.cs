using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

/// <summary>
/// 序列化
/// </summary>
public class Serialize
{
    private GameManage gameManage = null;
    public Serialize(GameManage gameManage)
    {
        this.gameManage = gameManage;
    }

    public void SaveRoleData()
    {
        if(Deserialization.Instance.RoleDatas.Count == 0)
        {
            return;
        }
        string str = JsonConvert.SerializeObject(Deserialization.Instance.RoleDatas);
        string path = Application.dataPath + "/Data/role.josn";
        File.WriteAllText(path, str);
    }
}
