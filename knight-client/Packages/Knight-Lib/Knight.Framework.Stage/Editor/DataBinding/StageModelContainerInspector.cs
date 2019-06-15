using NaughtyAttributes.Editor;
using UnityEditor;

namespace Knight.Framework.Stage
{
    [CustomEditor(typeof(StageControllerContainer), true)]
    public class StageModelContainerInspector : InspectorEditor
    {
        private StageControllerContainer mTarget;

        protected override void OnEnable()
        {
            base.OnEnable();
            mTarget = this.target as StageControllerContainer;
        }

        public override void OnInspectorGUI()
        {
            this.mTarget.GetAllViewModelDataSources();

            base.OnInspectorGUI();
            this.serializedObject.ApplyModifiedProperties();
        }
    }
}
