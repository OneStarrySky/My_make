using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAsset
{
	// Singleton模版
	private static LoadAsset _instance;
	public static LoadAsset Instance
	{
		get
		{
			if (_instance == null)
				_instance = new LoadAsset();
			return _instance;
		}
	}

	private Dictionary<LoadAssetType,Dictionary<string, Object>> m_assets = 
		new Dictionary<LoadAssetType,Dictionary<string, Object>>();

	public T LoadResources<T>(LoadAssetType assetType, string assetName)where T: Object
    {
		Object _obj = null;
		if (m_assets.ContainsKey(assetType))
		{
			if (m_assets[assetType].ContainsKey(assetName))
			{
				return (T)m_assets[assetType][assetName];
			}
		}
		else
		{
			m_assets[assetType] = new Dictionary<string, Object>();
		}
		_obj = Resources.Load<T>(assetType.ToString() + "/" + assetName);
		m_assets[assetType].Add(assetName, _obj);

		return (T)_obj;
    }
}
public enum LoadAssetType
{
	UI,
	Sprites,
	Effect,
	AudioClip,
	Model
}