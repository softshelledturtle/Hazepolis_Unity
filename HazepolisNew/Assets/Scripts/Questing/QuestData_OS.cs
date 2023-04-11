using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest/Quest Data")]
public class QuestData_SO : ScriptableObject
{
	[System.Serializable]
	public class QuestRequire
	{
		public string name;
		public int requireAmount;
		public int currentAmount;
	}


	public string questName;
	[TextArea]
	public string description;

	//需要三種任務完成的狀態，npc才會有不同的反應
	public bool isStarted;
	public bool isComplete;
	public bool isFinised;

	public List<QuestRequire> questRequires = new List<QuestRequire>();

}