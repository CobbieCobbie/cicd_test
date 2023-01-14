using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EnvironmentBehaviour
{
    public class WallMonitorFlickerBehaviour : MonoBehaviour
    {
        public string dialogId;
        public bool activateOnStart = true;
        [Tooltip("Only for first iteration")] public bool blockControlsUntilFinished = false;
        public float secondsToWaitWithStart = 0f;
        public int secondsForEachText = 6;
        private int _currentIndex = 0;
        private bool _allowToggling = false;

        private GameObject _whiteScreen = null;
        private GameObject _textField = null;
        private TextMeshPro _textMeshPro = null;
        private string[] _textsToShow;

        private void Start()
        {
            //if (!DialogDataSettings.Dialogs.TryGetValue(dialogId, out _textsToShow))
            {
                _textsToShow = new[] {"404"};
            }

            // Don't block controls if this is not the first iteration
            //if (GlobalGameSettings.GetLastPlayedLevelIteration() != 0) blockControlsUntilFinished = false;

            if (activateOnStart) ManualUpdate();
        }

        public void SetTextsToShow(string[] textsToShow)
        {
            _textsToShow = textsToShow;
        }

        public bool HasTextsToShow()
        {
            return _textsToShow != null && _textsToShow.Length > 0;
        }

        public void ManualUpdate()
        {
            _whiteScreen = transform.Find("ScreenWhite").gameObject;
            _textField = transform.Find("Text").gameObject;

            SetInactive();

            _textMeshPro = _textField.GetComponent<TextMeshPro>();
            _textMeshPro.SetText("");

            StartCoroutine(Init());
        }

        public void ResetScript()
        {
            _currentIndex = 0;
        }

        private IEnumerator Init()
        {
            if (blockControlsUntilFinished)
            {
                //GameManager.Instance.EnablePlayerMovement(false);
            }

            if (secondsToWaitWithStart != 0)
            {
                SetInactive();
                yield return new WaitForSeconds(secondsToWaitWithStart);
            }

            StartCoroutine(FlickerScreen());
            StartCoroutine(NextText());
        }

        private IEnumerator NextText()
        {
            if (_textsToShow != null && _currentIndex < _textsToShow.Length)
            {
                _textMeshPro.SetText(_textsToShow[_currentIndex++]);
                SetActive();
                _allowToggling = false;
                yield return new WaitForSeconds(secondsForEachText / 2f);
                _allowToggling = true;
                yield return new WaitForSeconds(secondsForEachText / 2f);
                StartCoroutine(NextText());
            }
            else
            {
                _allowToggling = false;
                SetInactive();
                if (blockControlsUntilFinished)
                {
                    //GameManager.Instance.EnablePlayerMovement(true);
                }
            }
        }

        private IEnumerator FlickerScreen()
        {
            if (_textsToShow == null || _currentIndex >= _textsToShow.Length) yield break;

            yield return new WaitForSeconds(Random.value);
            if (_allowToggling) ToggleState();
            StartCoroutine(FlickerScreen());
        }

        private void SetActive()
        {
            _whiteScreen.SetActive(true);
            _textField.SetActive(true);
        }

        private void SetInactive()
        {
            _whiteScreen.SetActive(false);
            _textField.SetActive(false);
        }

        private void ToggleState()
        {
            _whiteScreen.SetActive(!_whiteScreen.activeSelf);
            _textField.SetActive(!_textField.activeSelf);
        }
    }
}