using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
using MvsKFC.Classes;

namespace MvsKFC.scenes
{
    class SelectScene : CCScene
    {
        public SelectScene()
        {
            base.init();
            //取得屏幕大小
            CCSize size = CCDirector.sharedDirector().getWinSize();
            //背景图
            CCSprite background = CCSprite.spriteWithFile("background//select");
            background.position = new CCPoint(size.width / 2, size.height / 2);
            this.addChild(background);
            // 两个人物的选择
            CCMenuItemSprite button_uncle = CCMenuItemSprite.itemFromNormalSprite(
                         CCSprite.spriteWithSpriteFrameName("selectM01.png"),
                         CCSprite.spriteWithSpriteFrameName("selectM02.png"),
                         this, click_start);
            //两个按钮
            CCMenuItemSprite button_kfc = CCMenuItemSprite.itemFromNormalSprite(
                         CCSprite.spriteWithSpriteFrameName("selectK01.png"),
                         CCSprite.spriteWithSpriteFrameName("selectK02.png"),
                         this, click_start);
            //MenuItem需要通过CCMenu组合
            CCMenu menu = CCMenu.menuWithItems(button_uncle, button_kfc);
            //设置到界面中间偏下
            menu.alignItemsHorizontallyWithPadding(120);
            menu.position = new CCPoint(size.width / 2, size.height / 2 - 20);
            this.addChild(menu);
        }

        private void click_start(CCObject sender)
        {
            var s = CCTransitionFade.transitionWithDuration(0.5f, GameRoot.pSelect_employee);
            CCDirector.sharedDirector().pushScene(s);

        }
        private void click_people(CCObject sender)
        {
            var s = CCTransitionFade.transitionWithDuration(0.5f, GameRoot.pSelect_employee);
            CCDirector.sharedDirector().pushScene(s);
        }
    }
}
