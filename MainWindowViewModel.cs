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
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Message> Messages { get; set; }

        public ICommand SendMessageCommand { get; set; }

        public Message CurrentMessage
        {
            get { return CurrentMessage; }
            set
            {
                if (value != null)
                {
                    CurrentMessage = new Message()
                    {
                        Name = value.Name,
                        DirectMessage = value.DirectMessage
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
                SendMessageCommand = new RelayCommand(() =>
                {
                    Messages.Add(new Message()
                    {
                        Name = CurrentMessage.Name,
                        DirectMessage = CurrentMessage.DirectMessage
                    });
                });
            }
        }
    }
}
