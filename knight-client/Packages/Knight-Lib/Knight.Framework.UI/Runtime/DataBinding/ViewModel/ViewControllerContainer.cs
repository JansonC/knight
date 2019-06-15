using System.Collections.Generic;
using NaughtyAttributes;

namespace UnityEngine.UI
{
    public class ViewControllerContainer : MonoBehaviour
    {
        [InfoBox("ViewModelClass can not be null.", InfoBoxType.Error, "IsViewControllerClassNull")]
        [Dropdown("ViewControllerClasses")]
        public string ViewControllerClass;

        [ReorderableList]
        [InfoBox("Hei bro!!!!! Some ViewModel has same key.", InfoBoxType.Error, "IsViewModelKeyRepeated")]
        public List<ViewModelDataSource> ViewModels;

        [ReorderableList] public List<EventBinding> EventBindings;

        [HideInInspector] public string[] ViewControllerClasses = new string[0];

        public void GetAllViewModelDataSources()
        {
            ViewModels = new List<ViewModelDataSource>(GetComponentsInChildren<ViewModelDataSource>(true));
            EventBindings = new List<EventBinding>(GetComponentsInChildren<EventBinding>(true));
            ViewControllerClasses = DataBindingTypeResolve.GetAllViews().ToArray();
        }

        private bool IsViewControllerClassNull()
        {
            return string.IsNullOrEmpty(ViewControllerClass);
        }

        private bool IsViewModelKeyRepeated()
        {
            if (ViewModels == null)
            {
                return false;
            }

            var rTempViewModels = new HashSet<ViewModelDataSource>(ViewModels);
            return rTempViewModels.Count < this.ViewModels.Count;
        }
    }
}
