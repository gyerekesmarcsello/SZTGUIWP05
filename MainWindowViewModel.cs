using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SZTGUIWorkhop5.Models;

namespace SZTGUIWorkhop5
{
    class MainWindowViewModel : ObservableRecipient
    {
       

        public RestCollection<ChatMessage> Messages { get; set; }

        private string tname;

        public string TName
        {
            get { return tname; }
            set { SetProperty(ref tname, value); }
        }

        private string tmessage;

        public string TMessage
        {
            get { return tmessage; }
            set { SetProperty(ref tmessage,value); }
        }


        public ICommand SendMessageCommand { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {


            if (!IsInDesignMode)
            {
                Messages = new RestCollection<ChatMessage>("http://localhost:19526/", "chatmessage", "hub");
                SendMessageCommand = new RelayCommand(() =>
                {
                    Messages.Add(new ChatMessage()
                    {
                        Name = TName,
                        DirectMessage = TMessage,
                        localDate = DateTime.Now
                    }) ;
                });
                
            }
        }
    }
}
