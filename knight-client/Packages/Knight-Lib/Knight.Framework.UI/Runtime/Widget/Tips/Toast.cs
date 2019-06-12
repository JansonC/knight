//======================================================================
//        Copyright (C) 2015-2020 Winddy He. All rights reserved
//        Email: hgplan@126.com
//======================================================================
using System.Collections;
using Knight.Core;

namespace UnityEngine.UI
{
    public class Toast : MonoBehaviour
    {
        public static Toast Instance { get; private set; }

        public Image TipBG;
        public Text TipText;
        public CanvasGroup TipGroup;

        private CoroutineHandler mCoroutineHandler;

       private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                gameObject.SetActive(false);
            }
        }

        public void Show(string rTextTip, float rTimeLength = 3.0f)
        {
            if (mCoroutineHandler != null)
            {
                CoroutineManager.Instance.Stop(mCoroutineHandler);
                mCoroutineHandler = null;
            }

            mCoroutineHandler = CoroutineManager.Instance.StartHandler(StartAnim(rTextTip, rTimeLength));
        }

        private IEnumerator StartAnim(string rTextTip, float rTimeLength)
        {
            gameObject.SetActive(true);
            TipText.text = rTextTip;
            yield return 0;

            float rCurTime = 0.0f;
            yield return new WaitUntil(() =>
            {
                TipGroup.alpha = Mathf.Lerp(1, 0, Mathf.InverseLerp(0, rTimeLength, rCurTime));
                rCurTime += Time.deltaTime;
                return rCurTime >= rTimeLength;
            });
            TipGroup.alpha = 0;
            gameObject.SetActive(false);
        }
    }
}
