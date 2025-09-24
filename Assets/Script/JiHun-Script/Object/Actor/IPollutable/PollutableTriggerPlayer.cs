using UnityEngine;

namespace jjh
{
    public class PollutableTriggerPlayer : PollutableBase
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
                _player = player;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player == _player)
                _player = null;
        }
        private void Update()
        {
            if (_player == null)
                return;
            // ������ ���ο��� �ѹ��� ȣ���
            PollutEffect();
        }
        private Player _player = null;
    }
}