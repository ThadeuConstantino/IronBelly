using UnityEngine;
using TMPro;
using IronBelly.Controller;

namespace IronBelly.Hud
{
    public class HudDisplay : MonoBehaviour
    {
        public TextMeshProUGUI _textHit;
        public TextMeshProUGUI _textSpawn;

        private void Update()
        {
            _textHit.text = GamePlayData.Hit.ToString();
            _textSpawn.text = GamePlayData.Spawned.ToString();
        }
    }
}