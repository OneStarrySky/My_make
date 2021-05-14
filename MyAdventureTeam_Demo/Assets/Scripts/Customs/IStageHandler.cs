using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 关卡界面
public abstract class IStageHandler
{
	protected IStageHandler m_NextHandler = null;// 下一个关卡
	protected bool finished = false;//是否完成该关卡

	//是否完成关卡
	public bool IsFinished
	{
		get { return finished; }
	}

	// 设定下一个关卡
	public IStageHandler SetNextHandler(IStageHandler NextHandler)
	{
		m_NextHandler = NextHandler;
		return m_NextHandler;
	}

	public abstract IStageHandler CheckStage();
	public abstract void Reset();
}
