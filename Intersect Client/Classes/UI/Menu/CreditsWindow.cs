﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Intersect.Client.Classes.UI.Menu;
using Intersect.Localization;
using IntersectClientExtras.File_Management;
using IntersectClientExtras.GenericClasses;
using IntersectClientExtras.Gwen;
using IntersectClientExtras.Gwen.Control;
using IntersectClientExtras.Gwen.Control.EventArguments;
using IntersectClientExtras.Gwen.ControlInternal;
using IntersectClientExtras.Input;
using Intersect_Client.Classes.Core;
using Intersect_Client.Classes.General;
using Intersect_Client.Classes.Misc;
using Intersect_Client.Classes.Networking;

namespace Intersect_Client.Classes.UI.Menu
{
    public class CreditsWindow
    {
        private MainMenu _mainMenu;
        private Button _backBtn;

        //Parent
        private Label _creditsHeader;
        //Content
        private ScrollControl _creditsContent;
        //Controls
        private ImagePanel _creditsWindow;

        //Init
        public CreditsWindow(Canvas parent, MainMenu mainMenu)
        {
            //Assign References
            _mainMenu = mainMenu;

            //Main Menu Window
            _creditsWindow = new ImagePanel(parent, "CreditsWindow");

            //Menu Header
            _creditsHeader = new Label(_creditsWindow, "CreditsHeader");
            _creditsHeader.SetText(Strings.Get("credits", "title"));

            _creditsContent = new ScrollControl(_creditsWindow, "CreditsScrollview");
            _creditsContent.EnableScroll(false, true);

            var creditsParser = new CreditsParser();
            var richLabel = new RichLabel(_creditsContent,"CreditsLabel");
            richLabel.SetSize(512, 393 - 35);
            foreach (var line in creditsParser.Credits)
            {
                if (line.text.Trim().Length == 0)
                {
                    richLabel.AddLineBreak();
                }
                else
                {
                    richLabel.AddText(line.text, new Color(line.clr.A,line.clr.R,line.clr.G,line.clr.B), line.alignment, GameContentManager.Current.GetFont(line.font,line.size));
                    richLabel.AddLineBreak();
                }
            }
            richLabel.SizeToChildren(false, true);

            //Back Button
            _backBtn = new Button(_creditsWindow, "BackButton");
            _backBtn.SetText(Strings.Get("credits", "back"));
            _backBtn.Clicked += BackBtn_Clicked;
        }

        private void BackBtn_Clicked(Base sender, ClickedEventArgs arguments)
        {
            Hide();
            _mainMenu.Show();
        }

        //Methods
        public void Update()
        {
        }

        public void Hide()
        {
            _creditsWindow.IsHidden = true;
        }

        public void Show()
        {
            _creditsWindow.IsHidden = false;
        }

    }
}