﻿//======================================================================
//        Copyright (C) 2015-2020 Winddy He. All rights reserved
//        Email: hgplan@126.com
//======================================================================

namespace Knight.Framework.Input
{
    public class JoystickInput : BaseInput
    {
        public JoystickInput() : base()
        {
        }

        public override float Horizontal
        {
            get { return Joystick.Instance.x; }
        }

        public override float Vertical
        {
            get { return Joystick.Instance.y; }
        }

        public override bool IsKeyDown(InputKey rInputKey)
        {
            throw new System.NotImplementedException();
        }

        public override bool IsKeyUp(InputKey rInputKey)
        {
            throw new System.NotImplementedException();
        }

        public override bool IsKey(InputKey rInputKey)
        {
            throw new System.NotImplementedException();
        }
    }
}
