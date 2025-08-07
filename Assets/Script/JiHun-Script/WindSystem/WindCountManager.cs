using System.Collections.Generic;
using UnityEngine;

public class WindCountManager
{
    public WindCountManager()
    {

    }
    public IJudgeWind ReturnCurrentJudgeWind() 
    {
        if (currentWindCount == maxWindCount)
            return impossibleJudge;
        return judgeWinds[currentWindCount];
    }
    public void AddJudgeWind(IJudgeWind judgeWind) 
    { 
        judgeWinds.Add(judgeWind);
        maxWindCount = judgeWinds.Count;
    }

    public void SetMaxCount() { currentWindCount = 0; }
    public void DecreaseCount() {  currentWindCount += 1; }

    private List<IJudgeWind> judgeWinds = new List<IJudgeWind>();
    private IJudgeWind impossibleJudge = new AlwaysFalseJudge();
    private int currentWindCount = 0;
    private int maxWindCount = 0;
}
