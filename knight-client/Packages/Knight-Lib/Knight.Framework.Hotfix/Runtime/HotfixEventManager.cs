//======================================================================
//        Copyright (C) 2015-2020 Winddy He. All rights reserved
//        Email: hgplan@126.com
//======================================================================
using System;
using Knight.Core;

namespace Knight.Framework.Hotfix
{
    public class HotfixEventManager : TSingleton<HotfixEventManager>
    {
        public class EventObject
        {
            public UnityEngine.Object Target;
            public HEventTriggerType Type;
            public event Action<UnityEngine.Object> Event;
            public int ReferCount;

            public EventObject(UnityEngine.Object rTarget, HEventTriggerType rType)
            {
                this.Target = rTarget;
                this.Type = rType;
            }

            public void Dispose()
            {
                this.Event = null;
                this.Target = null;
                this.ReferCount = 0;
            }

            public void AddEvent(Action<UnityEngine.Object> rAction)
            {
                this.Event += rAction;
                this.ReferCount++;
            }

            public void RemoveEvent(Action<UnityEngine.Object> rAction)
            {
                this.Event -= rAction;
                this.ReferCount--;

                if (this.ReferCount < 0)
                {
                    this.ReferCount = 0;
                }
            }

            public void Handle()
            {
                if (this.Event != null)
                {
                    this.Event(this.Target);
                }
            }
        }

        public class EventTypeObject
        {
            public UnityEngine.Object TargetGo;
            public Dict<HEventTriggerType, EventObject> EventTypeObjs;

            public EventTypeObject(UnityEngine.Object rTargetGo)
            {
                this.TargetGo = rTargetGo;
                this.EventTypeObjs = new Dict<HEventTriggerType, EventObject>();
            }

            public void AddEvent(HEventTriggerType rEventType, System.Action<UnityEngine.Object> rEventHandler)
            {
                EventObject rEventObject = null;
                if (!this.EventTypeObjs.TryGetValue(rEventType, out rEventObject))
                {
                    rEventObject = new EventObject(this.TargetGo, rEventType);
                    rEventObject.AddEvent(rEventHandler);
                    EventTypeObjs.Add(rEventType, rEventObject);
                }
                else
                {
                    rEventObject.AddEvent(rEventHandler);
                }
            }

            public void RemoveEvent(HEventTriggerType rEventType, Action<UnityEngine.Object> rAction)
            {
                EventObject rEventObject = null;
                if (this.EventTypeObjs.TryGetValue(rEventType, out rEventObject))
                {
                    rEventObject.RemoveEvent(rAction);
                }

                if (rEventObject != null && rEventObject.ReferCount == 0)
                {
                    rEventObject.Dispose();
                    this.EventTypeObjs.Remove(rEventType);
                }
            }

            public void RemoveAll()
            {
                foreach (var rItem in EventTypeObjs)
                {
                    rItem.Value.Dispose();
                }

                EventTypeObjs.Clear();
            }

            public void Handle(HEventTriggerType rEventType)
            {
                EventObject rEventObject = null;
                if (this.EventTypeObjs.TryGetValue(rEventType, out rEventObject))
                {
                    rEventObject.Handle();
                }
            }

            public void Dispose()
            {
                foreach (var rItem in EventTypeObjs)
                {
                    if (rItem.Value.ReferCount == 0)
                    {
                        rItem.Value.Dispose();
                    }
                }
            }

            public int ReferCount
            {
                get
                {
                    int nReferCount = 0;
                    foreach (var rItem in EventTypeObjs)
                    {
                        nReferCount += rItem.Value.ReferCount;
                    }

                    return nReferCount;
                }
            }

            public void Remove(HEventTriggerType rEventType)
            {
                EventObject rEventObject = null;
                if (this.EventTypeObjs.TryGetValue(rEventType, out rEventObject))
                {
                    rEventObject.Dispose();
                }

                this.EventTypeObjs.Remove(rEventType);
            }
        }

        public Dict<UnityEngine.Object, EventTypeObject> Events { get; private set; }

        private HotfixEventManager()
        {
        }

        public void Initialize()
        {
            // 加载Hotfix端的代码
            Events = new Dict<UnityEngine.Object, EventTypeObject>();
        }

        public void Handle(UnityEngine.Object rTargetGo, HEventTriggerType rEventType)
        {
            if (this.Events == null)
            {
                return;
            }

            EventTypeObject rEventObject = null;
            if (this.Events.TryGetValue(rTargetGo, out rEventObject))
            {
                rEventObject.Handle(rEventType);
            }
        }

        public void Binding(UnityEngine.Object rTargetGo, HEventTriggerType rEventType,
            Action<UnityEngine.Object> rEventHandler)
        {
            EventTypeObject rEventObject = null;
            if (!this.Events.TryGetValue(rTargetGo, out rEventObject))
            {
                rEventObject = new EventTypeObject(rTargetGo);
                rEventObject.AddEvent(rEventType, rEventHandler);
                Events.Add(rTargetGo, rEventObject);
            }
            else
            {
                rEventObject.AddEvent(rEventType, rEventHandler);
            }
        }

        public void UnBinding(UnityEngine.Object rTargetGo, HEventTriggerType rEventType,
            Action<UnityEngine.Object> rEventHandler)
        {
            EventTypeObject rEventObject = null;
            if (this.Events.TryGetValue(rTargetGo, out rEventObject))
            {
                rEventObject.RemoveEvent(rEventType, rEventHandler);
            }

            if (rEventObject != null && rEventObject.ReferCount == 0)
            {
                rEventObject.Dispose();
                this.Events.Remove(rTargetGo);
            }
        }

        public void RemoveOne(UnityEngine.Object rObj)
        {
            EventTypeObject rEventObject = null;
            if (this.Events.TryGetValue(rObj, out rEventObject))
            {
                rEventObject.Dispose();
                this.Events.Remove(rObj);
            }
        }

        public void RemoveAll()
        {
            foreach (var rItem in Events)
            {
                rItem.Value.Dispose();
            }

            Events.Clear();
        }
    }
}
