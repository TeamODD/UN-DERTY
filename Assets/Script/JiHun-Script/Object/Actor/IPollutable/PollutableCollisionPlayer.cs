using UnityEngine;

namespace jjh
{
    public class PollutableCollisionPlayer : PollutableBase
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
                _player = player;
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player == _player)
                _player = null;
        }
        private void Update()
        {
            if (_player == null)
                return;
            // 어차피 내부에서 한번만 호출됌
            PollutEffect();
        }
        private Player _player = null;
    }
}