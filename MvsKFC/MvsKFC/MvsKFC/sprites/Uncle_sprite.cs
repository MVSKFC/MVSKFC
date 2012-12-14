using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
using MvsKFC.Data;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework;

namespace MvsKFC.sprites
{
    class Uncle_sprite : CCSprite
    {
        //public UncleData uncledata { get; set; }
        int l_r;
        int xx = 100;
        Accelerometer gSensor;
        private CCAnimate _run;
        private CCAnimate _actack;
        public Uncle_sprite()
        {
            //uncledata = data;

            // 创建走的动画
            List<CCSpriteFrame> _runFream = new List<CCSpriteFrame>();
            CCSpriteFrameCache.sharedSpriteFrameCache().addSpriteFramesWithFile(@"plist/zhengyu");
            CCSpriteBatchNode sheet = CCSpriteBatchNode.batchNodeWithFile(@"plist/Images/zhengyu");
            this.addChild(sheet);
            for (int i = 1; i <= 4; i++)
            {
                _runFream.Add(CCSpriteFrameCache.sharedSpriteFrameCache().spriteFrameByName(String.Format("MM0{0}.png", i)));

            }
            _run = CCAnimate.actionWithAnimation(CCAnimation.animationWithFrames(_runFream, 0.12f));

            List<CCSpriteFrame> _actackFream = new List<CCSpriteFrame>();
            // 创建攻击时候动作
            for (int i = 1; i <= 5; i++)
            {
                _actackFream.Add(CCSpriteFrameCache.sharedSpriteFrameCache().spriteFrameByName(String.Format("Mthrow0{0}.png", i)));

            }
            _actack = CCAnimate.actionWithAnimation(CCAnimation.animationWithFrames(_actackFream, 0.3f));

            position = new CCPoint(100, 100);
            // 初始化开始帧
            base.initWithSpriteFrame(_runFream[0]);

            
            // 如果手机倾斜
            if (Accelerometer.IsSupported)
            {
                gSensor = new Accelerometer();
                gSensor.CurrentValueChanged += new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(gSensor_CurrentValueChanged);
                gSensor.Start();
            }
        }

        void gSensor_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            CCPoint newPos = new CCPoint(position.x, position.y);
            Vector3 vector3 = e.SensorReading.Acceleration;
            if (vector3.Y <= 0.2 && vector3.Y > 0)
            {
                
                //RunAnimateAction_RepeatForever(_run);
                runAction(CCMoveTo.actionWithDuration(1, new CCPoint(60, 100)));
            }
            else if (vector3.Y <= 0 && vector3.Y > -0.2)
            {
                runAction(CCMoveTo.actionWithDuration(1, new CCPoint(300, 100)));
                RunAnimateAction_RepeatForever(_run);
            }
        }

        CCAction _currentAnimateAction;
        public void run()
        {
            //runAction(CCMoveTo.actionWithDuration(1, new CCPoint(300, 100)));
            if (l_r == 1)
            {
                //xx += 20;
                //runAction(CCMoveTo.actionWithDuration(1, new CCPoint(xx, 100)));
                //RunAnimateAction_RepeatForever(_run);
            }
            if (l_r == 2)
            {
                //xx -= 20;
                //runAction(CCMoveTo.actionWithDuration(1, new CCPoint(xx, 100)));
                //RunAnimateAction_RepeatForever(_run);
            }
            
        }

        public void actack()
        {
            RunAnimateAction_RepeatForever(_actack);
        }

        //停止当前的动画
        public void currentAnimateActionStop()
        {
            if (_currentAnimateAction != null)
                this.stopAction(_currentAnimateAction);
        }
        //播放循环动画的统一方法
        private void RunAnimateAction_RepeatForever(CCAnimate action)
        {
            currentAnimateActionStop();
            _currentAnimateAction = runAction(CCRepeatForever.actionWithAction(action));
        }


    }
}
