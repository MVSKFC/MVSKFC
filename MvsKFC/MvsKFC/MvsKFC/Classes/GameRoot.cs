using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
using MvsKFC.scenes;

namespace MvsKFC.Classes
{
    class GameRoot
    {
        public static void InitializeResource()
        {
            CCSpriteFrameCache.sharedSpriteFrameCache().addSpriteFramesWithFile(@"plist/left_right");
  
        }

        private static SelectScene _SelectScene;
        public static SelectScene pSelectScene
        {
            get
            {
                if (_SelectScene == null)
                    _SelectScene = new SelectScene();
                return _SelectScene;
            }
        }

        private static GameScene _GameScene;
        public static GameScene pGameScene
        {
            get
            {
                if (_GameScene == null)
                    _GameScene = new GameScene();
                return _GameScene;
            }
        }

        private static Select_employee _Select_employee;
        public static Select_employee pSelect_employee
        {
            get
            {
                if (_Select_employee == null)
                    _Select_employee = new Select_employee();
                return _Select_employee;
            }
        }


    }
}
