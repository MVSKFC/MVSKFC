using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;

namespace MvsKFC.select
{
    class Employee : CCLayer 
    {

        CCSize size = CCDirector.sharedDirector().getWinSize();
        public Employee()
        {
            // 人物头像添加
            CCMenuItemImage btn_start = CCMenuItemImage.itemFromNormalImage(@"UI/star", "UI/select", this, OK);
            CCMenu m = CCMenu.menuWithItems(btn_start);
            m.position = new CCPoint(size.width / 2, size.height / 2);
            m.visible = false;
            this.addChild(m);

        }

        public void Show()
        {
            //将其显示出来
            this.visible = true;
            //把位置设置到最右边出屏幕外
            this.position = new CCPoint(CCDirector.sharedDirector().getWinSize().width, 0);
            //指定移动到0，0点
            CCMoveTo move = CCMoveTo.actionWithDuration(0.5f, new CCPoint(0, 0));
            //运行这个Action
            this.runAction(move);
        }
        public void Hide()
        {
            //指定移动到最左边并超出屏幕
            CCMoveTo move = CCMoveTo.actionWithDuration(0.5f, new CCPoint(-CCDirector.sharedDirector().getWinSize().width, 0));
            //执行一个队列行为，当移动完成后就会调用HideAniCompled
            this.runAction(CCSequence.actionOneTwo(move, CCCallFunc.actionWithTarget(this, HideAniCompled)));
        }

        public void buy()
        {
        }

        void HideAniCompled()
        {
            this.visible = false;
        }

        public void OK(CCObject sender)
        {
            visible = false;
        }
    }
}
