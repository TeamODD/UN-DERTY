using UnityEngine;

public class Pillow : UseItem
{
    public Pillow(int count) 
        : base("Pillow", count)
    {
    }

    public override void Use()
    {
        // ‘다시하기’ 시 DP를 스테이지 입장 & 해당 시점 값으로 복원
    }
}
