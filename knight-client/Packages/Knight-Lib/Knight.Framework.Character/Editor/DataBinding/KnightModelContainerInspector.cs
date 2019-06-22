using NaughtyAttributes.Editor;
using UnityEditor;

namespace Knight.Framework.Character
{
    [CustomEditor(typeof(KnightControllerContainer), true)]
    public class KnightModelContainerInspector : InspectorEditor
    {
        private KnightControllerContainer mTarget;

        protected override void OnEnable()
        {
            base.OnEnable();
            mTarget = target as KnightControllerContainer;
        }

        public override void OnInspectorGUI()
        {
            mTarget.GetAllViewModelDataSources();
            base.OnInspectorGUI();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
