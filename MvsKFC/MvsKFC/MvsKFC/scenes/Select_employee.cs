using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
using MvsKFC.Classes;

namespace MvsKFC.scenes
{
    class Select_employee : CCScene
    {

        public Select_employee()
        {
            #region UI布置
            CCSize size = CCDirector.sharedDirector().getWinSize();
            CCSpriteFrameCache.sharedSpriteFrameCache().addSpriteFramesWithFile(@"plist/left_right");
            base.init();
            // 背景

            // 开始游戏按钮
            CCMenuItemImage star_button = CCMenuItemImage.itemFromNormalImage("UI/PK", "UI/PK1", this, click_star);
            CCMenu starMenu = CCMenu.menuWithItems(star_button);
            starMenu.position = new CCPoint(size.width - 60, size.height - 50);
            this.addChild(starMenu);

            // 返回按钮
            CCMenuItemImage back_button = CCMenuItemImage.itemFromNormalImage("CloseSelected", "CloseNormal", this, click_back);
            CCMenu backMenu = CCMenu.menuWithItems(back_button);
            backMenu.position = new CCPoint(size.width - 20, 40);
            this.addChild(backMenu);
            // 左右边移动键
            CCMenuItemSprite left_button = CCMenuItemSprite.itemFromNormalSprite(
                CCSprite.spriteWithSpriteFrameName("left_select.png"),
                CCSprite.spriteWithSpriteFrameName("left.png"),
                this, left);
            CCMenuItemSprite right_button = CCMenuItemSprite.itemFromNormalSprite(
                CCSprite.spriteWithSpriteFrameName("right_select.png"),
                CCSprite.spriteWithSpriteFrameName("right.png"),
                this, right);
            CCMenu select_menu = CCMenu.menuWithItems(left_button, right_button);
            select_menu.alignItemsHorizontallyWithPadding(440);
            select_menu.position = new CCPoint(size.width / 2 , size.height / 4 * 3);
            this.addChild(select_menu);
            #endregion

            // 员工
        }

        public void click_back(CCObject s)
        {
            var a = CCTransitionFade.transitionWithDuration(0.5f, GameRoot.pSelectScene);
            CCDirector.sharedDirector().pushScene(a); 
        }

        public void click_star(CCObject sender)
        {
            var s = CCTransitionFade.transitionWithDuration(0.5f, GameRoot.pGameScene);
            CCDirector.sharedDirector().pushScene(s);
        }

        public void buy(CCObject sender)
        { }

        public void left(CCObject sender)
        { }

        public void right(CCObject sender)
        { }
    }
}
