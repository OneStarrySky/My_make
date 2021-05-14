using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 关卡
/// </summary>
public class NormalStageHandler : IStageHandler
{
	private StageData stagData = null;
	// 设定关卡资料
	public NormalStageHandler(StageData stagData)
	{
		this.stagData = stagData;
	}

	// 确认关卡
	public override IStageHandler CheckStage()
	{
		// 是否最后一关
		if (m_NextHandler == null)
			return this;

		// 确认下一个关卡
		return m_NextHandler.CheckStage();
	}

	public override void Reset()
	{

	}
}
