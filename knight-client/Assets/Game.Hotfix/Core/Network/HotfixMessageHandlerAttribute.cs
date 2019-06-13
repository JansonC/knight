﻿using System;

namespace Knight.Hotfix.Core
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HotfixMessageHandlerAttribute : Attribute
    {
        public ushort Opcode;

        public HotfixMessageHandlerAttribute(ushort nOpcode)
        {
            this.Opcode = nOpcode;
        }
    }
}
