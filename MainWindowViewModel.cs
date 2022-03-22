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

        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { SetProperty(ref message,value); }
        }


        public ICommand SendMessageCommand { get; set; }

        public ChatMessage CurrentMessage
        {
            get { return CurrentMessage; }
            set
            {
                if (value != null)
                {
                    CurrentMessage = new ChatMessage()
                    {
                        Name = value.Name,
                        DirectMessage = value.DirectMessage,
                        localDate=value.localDate
                        
                    };
                    OnPropertyChanged();
                }
            }
        }

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
                Messages = new RestCollection<ChatMessage>("http://localhost:19526/", "chat", "hub");
                SendMessageCommand = new RelayCommand(() =>
                {
                    Messages.Add(new ChatMessage()
                    {
                        Name = CurrentMessage.Name,
                        DirectMessage = CurrentMessage.DirectMessage,
                        localDate = CurrentMessage.localDate
                    });
                });
            }
        }
    }
}
