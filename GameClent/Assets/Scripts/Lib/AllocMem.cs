using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[ExecuteInEditMode ()]
public class AllocMem : MonoBehaviour {
	
	public bool show = true;
	public bool showInEditor = false;
	public GUIStyle fontStyle = new GUIStyle();

	void Awake() {
		useGUILayout = false;
		fontStyle.normal.textColor = Color.green;
#if UNITY_EDITOR
		fontStyle.fontSize = 12;
#else
		fontStyle.fontSize = 30;
#endif
	}

	// Use this for initialization
	public void OnGUI () {
		if (!show || (!Application.isPlaying && !showInEditor)) {
			return;
		}
		
		int collCount = System.GC.CollectionCount (0);
		
		if (lastCollectNum != collCount) {
			lastCollectNum = collCount;
			delta = Time.realtimeSinceStartup-lastCollect;
			lastCollect = Time.realtimeSinceStartup;
			lastDeltaTime = Time.deltaTime;
			collectAlloc = allocMem;
		}
		
		allocMem = (int)System.GC.GetTotalMemory (false);
		
		peakAlloc = allocMem > peakAlloc ? allocMem : peakAlloc;
		
		if (Time.realtimeSinceStartup - lastAllocSet > 0.3F) {
			int diff = allocMem - lastAllocMemory;
			lastAllocMemory = allocMem;
			lastAllocSet = Time.realtimeSinceStartup;
			
			if (diff >= 0) {
				allocRate = diff;
			}
		}
		
		float fps = 1f/Time.deltaTime;
		fpsCollection.Add(fps);
		fpsTimeCount += Time.deltaTime;
		if (fpsTimeCount >= 1f)
		{
			fpsTimeCount = 0f;
			fpsAverage = fpsCollection.Average();
			fpsCollection.Clear();
		}

		uint totalUsedMemory = UnityEngine.Profiling.Profiler.GetTotalAllocatedMemory (); // == Profiler.usedHeapSize
		uint totalSizeMemory = UnityEngine.Profiling.Profiler.GetTotalReservedMemory ();
		peakTotalUsedMemory = totalUsedMemory > peakTotalUsedMemory ? totalUsedMemory : peakTotalUsedMemory;
		peakTotalSizeMemory = totalSizeMemory > peakTotalSizeMemory ? totalSizeMemory : peakTotalSizeMemory;

		StringBuilder text = new StringBuilder ();
		
		text.Append ("FPS                                                         ");
		text.Append (string.Format("{0:f1} (Average {1:f1})\n", fps, fpsAverage));

		text.Append ("Main memory			");
		text.Append (string.Format("{0:#,0}MB\n", SystemInfo.systemMemorySize));

		text.Append ("Allocated memory		");
		text.Append (string.Format("{0:f1}MB (Peak {1:f1}MB)\n", totalUsedMemory/1000000f, peakTotalUsedMemory/1000000f));

		text.Append ("Reserved memory		");
		text.Append (string.Format("{0:f1}MB (Peak {1:f1}MB)\n", totalSizeMemory/1000000f, peakTotalSizeMemory/1000000f));
		
		text.Append ("GC allocated memory		");
		text.Append (string.Format("{0:f1}MB (Peak {1:f1}MB)\n", allocMem/1000000f, peakAlloc/1000000f));
		
//		text.Append ("Allocation rate				");
//		text.Append ((allocRate/1000000F).ToString ("0.0") + "MB\n");
//		
//		text.Append ("Collection frequency			");
//		text.Append (delta.ToString ("0.00") + "s\n");
//		
//		text.Append ("Last collect delta			");
//		text.Append (lastDeltaTime.ToString ("0.000") + "s (" + (1F/lastDeltaTime).ToString ("0.0") + " FPS)\n");

		var output = text.ToString ();
		var lineNum = CountChar(output, '\n') + 1;
		GUI.Box (new Rect (5,5,fontStyle.fontSize*30,fontStyle.fontSize*(lineNum+1)),"");
		GUI.Label (new Rect (10,10,fontStyle.fontSize*100,fontStyle.fontSize*(lineNum+1)), output, fontStyle);
	}
	
	public static int CountChar(string s, char c) {
		return s.Length - s.Replace(c.ToString(), "").Length;
	}

	private float lastCollect = 0;
	private float lastCollectNum = 0;
	private float delta = 0;
	private float lastDeltaTime = 0;
	private int allocRate = 0;
	private int lastAllocMemory = 0;
	private float lastAllocSet = -9999;
	private int allocMem = 0;
	private int collectAlloc = 0;
	private int peakAlloc = 0;
	private uint peakTotalUsedMemory = 0;
	private uint peakTotalSizeMemory = 0;
	private float fpsAverage = 0f;
	private List<float> fpsCollection = new List<float>();
	private float fpsTimeCount = 0f;
}