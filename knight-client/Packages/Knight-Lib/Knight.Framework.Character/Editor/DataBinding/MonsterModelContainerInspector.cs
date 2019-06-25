using NaughtyAttributes.Editor;
using UnityEditor;

namespace Knight.Framework.Character
{
    [CustomEditor(typeof(MonsterControllerContainer), true)]
    public class MonsterModelContainerInspector : InspectorEditor
    {
        private MonsterControllerContainer mTarget;

        protected override void OnEnable()
        {
            base.OnEnable();
            mTarget = target as MonsterControllerContainer;
        }

        public override void OnInspectorGUI()
        {
            mTarget.GetAllViewModelDataSources();
            base.OnInspectorGUI();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
