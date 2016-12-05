// ---------------------------------------
// File: PlayerAttack.cs
// 
// Date: 2016/12/01
// 
// Author: Y.Watanabe
// ---------------------------------------

using UnityEngine;
using System.Collections;
using UniRx.Triggers;
using UniRx;

public class PlayerAttack : MonoBehaviour
{
	#region variable

	//IntReactiveProperty deadStream = new IntReactiveProperty(10);

	//public IObservable<int> DeadStream
	//{
	//	get { return deadStream.AsObservable().Where(hp => hp <= 0); }
	//}

	#endregion

	#region method

	/// <summary> 
	/// 更新前処理
	/// </summary>
	void Start ()
	{
		this.UpdateAsObservable()
			.Where(_ => Input.GetButtonDown("Fire1"))
			.Subscribe(_ => Debug.Log("fire"));

	}

	#endregion
}
