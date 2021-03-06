﻿//======================================================================
//        Copyright (C) 2015-2020 Winddy He. All rights reserved
//        Email: hgplan@126.com
//======================================================================
using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Knight.Core
{
    [ExecuteInEditMode]
    public class TEditorUpdateMB<T> : MonoBehaviour where T : MonoBehaviour
    {
        void Awake()
        {
            this.AwakeCustom();
#if UNITY_EDITOR
            EditorApplication.update += OnEditorUpdate;
#endif
        }

        void OnDestroy()
        {
            this.DestroyCustom();
#if UNITY_EDITOR
            EditorApplication.update -= OnEditorUpdate;
#endif
        }
        
        void Update()
        {
            if (!Application.isPlaying) return;
            UpdateCustom();
        }

        void OnEditorUpdate()
        {
            if (Application.isPlaying) return;
            UpdateCustom();
        }

        protected virtual void UpdateCustom()
        {
        }

        protected virtual void AwakeCustom()
        {
        }

        protected virtual void DestroyCustom()
        {
        }
    }
}
