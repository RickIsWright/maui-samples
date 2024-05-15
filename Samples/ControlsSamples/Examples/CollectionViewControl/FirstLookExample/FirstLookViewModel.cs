﻿using Microsoft.Maui.Graphics;
using QSF.ViewModels;
using System.Collections.ObjectModel;

namespace QSF.Examples.CollectionViewControl.FirstLookExample;

public class FirstLookViewModel : ExampleViewModel
{
    public FirstLookViewModel()
    {
        this.Messages = new ObservableCollection<MessageData>
        {
            new MessageData{ Sender = "Eva Lawson", Message = "You: Hi, Thank you for the update.", MessageDelivered = "13:13", BackgroundColor = Color.FromArgb("#FFE6C5"), TextColor = Color.FromArgb("#FFAC3E"), StatusColor = Color.FromArgb("#60C858") },
            new MessageData{ Sender = "Layton Buck", Message = "Greetings Tom, My name is Layton.", MessageDelivered = "12:23", BackgroundColor = Color.FromArgb("#FECAD1"), TextColor = Color.FromArgb("#FD5064"), StatusColor = Color.FromArgb("#60C858") },
            new MessageData{ Sender = "Chester Harvey", Message = "You: Bye!", MessageDelivered = "12:12", BackgroundColor = Color.FromArgb("#FECAD1"), TextColor = Color.FromArgb("#FD5064"), StatusColor = Color.FromArgb("#F85446") },
            new MessageData{ Sender = "Jenny Fuller", Message = "Short break?", MessageDelivered = "11:11", BackgroundColor = Color.FromArgb("#D3F2F3"), TextColor = Color.FromArgb("#55D3DE"), StatusColor = Color.FromArgb("#60C858") },
            new MessageData{ Sender = "Ashley Robertson", Message = "You: Going to a meeting in a few minutes.", MessageDelivered = "10:35", BackgroundColor = Color.FromArgb("#FFE6C5"), TextColor = Color.FromArgb("#FFAC3E"), StatusColor = Color.FromArgb("#60C858") },
            new MessageData{ Sender = "Niki Samaniego", Message = "You: See you tomorrow.", MessageDelivered = "10:34", BackgroundColor = Color.FromArgb("#FFE6C5"), TextColor = Color.FromArgb("#FFAC3E"), StatusColor = Color.FromArgb("#60C858") },
            new MessageData{ Sender = "Armstrong Robbie ", Message = "I will discuss it with the PO.", MessageDelivered = "09:11", BackgroundColor = Color.FromArgb("#FECAD1"), TextColor = Color.FromArgb("#FD5064"), StatusColor = Color.FromArgb("#F85446") },
            new MessageData{ Sender = "Coby Ryan", Message = "OK", MessageDelivered = "09:05", BackgroundColor = Color.FromArgb("#CCE7CB"), TextColor = Color.FromArgb("#56AF51"), StatusColor = Color.FromArgb("#F85446") },
            new MessageData{ Sender = "Davis Anderson", Message = "You: Okay, thank you for the update.", MessageDelivered = "08:11", BackgroundColor = Color.FromArgb("#FECAD1"), TextColor = Color.FromArgb("#FD5064"), StatusColor = Color.FromArgb("#60C858") },
            new MessageData{ Sender = "Quincy Sanchez", Message = "Waiting for a reply...", MessageDelivered = "yesterday", BackgroundColor = Color.FromArgb("#D3F2F3"), TextColor = Color.FromArgb("#55D3DE"), StatusColor = Color.FromArgb("#F85446") },
            new MessageData{ Sender = "Konny Mills", Message = "Do you need this tool for your projects?", MessageDelivered = "yesterday", BackgroundColor = Color.FromArgb("#CCE7CB"), TextColor = Color.FromArgb("#56AF51"), StatusColor = Color.FromArgb("#F85446") },
            new MessageData{ Sender = "Casper Fletcher", Message = "You: See you!", MessageDelivered = "yesterday", BackgroundColor = Color.FromArgb("#FFE6C5"), TextColor = Color.FromArgb("#FFAC3E"), StatusColor = Color.FromArgb("#F85446") },
            new MessageData{ Sender = "Barnes Ashton ", Message = "No, I am not OK.", MessageDelivered = "13.12", BackgroundColor = Color.FromArgb("#CCE7CB"), TextColor = Color.FromArgb("#56AF51"), StatusColor = Color.FromArgb("#F85446") },
            new MessageData{ Sender = "Bob Carty", Message = "You: Hello, Can I ask you...", MessageDelivered = "10.12", BackgroundColor = Color.FromArgb("#FFE6C5"), TextColor = Color.FromArgb("#FFAC3E"), StatusColor = Color.FromArgb("#F85446") },
            new MessageData{ Sender = "Angus Barnes", Message = "Looking forward to seeing you!", MessageDelivered = "19.11", BackgroundColor = Color.FromArgb("#CCE7CB"), TextColor = Color.FromArgb("#56AF51"), StatusColor = Color.FromArgb("#F85446") },
            new MessageData{ Sender = "Vada Davies", Message = "You: Looking forward to your reply.", MessageDelivered = "16.11", BackgroundColor = Color.FromArgb("#CCE7CB"), TextColor = Color.FromArgb("#56AF51"), StatusColor = Color.FromArgb("#60C858") },
            new MessageData{ Sender = "David Webb", Message = "You: Gretings, I wanted to ask you ...", MessageDelivered = "14.11", BackgroundColor = Color.FromArgb("#D3F2F3"), TextColor = Color.FromArgb("#55D3DE"), StatusColor = Color.FromArgb("#60C858") },
            new MessageData{ Sender = "Nida Carty", Message = "Currently, I am working as a .NET Developer.", MessageDelivered = "14.11", BackgroundColor = Color.FromArgb("#CCE7CB"), TextColor = Color.FromArgb("#56AF51"), StatusColor = Color.FromArgb("#60C858") },
            new MessageData{ Sender = "Jeffery Francis", Message = "I'll be back in 10 mins.", MessageDelivered = "14.11", BackgroundColor = Color.FromArgb("#FECAD1"), TextColor = Color.FromArgb("#FD5064"), StatusColor = Color.FromArgb("#60C858") },
            new MessageData{ Sender = "Terrell Norris", Message = "See you soon.", MessageDelivered = "14.11", BackgroundColor = Color.FromArgb("#D3F2F3"), TextColor = Color.FromArgb("#55D3DE"), StatusColor = Color.FromArgb("#F85446") },
            new MessageData{ Sender = "Greg Nikolas", Message = "You: Sending you best wishes!", MessageDelivered = "13.11", BackgroundColor = Color.FromArgb("#FECAD1"), TextColor = Color.FromArgb("#FD5064"), StatusColor = Color.FromArgb("#F85446") },
            new MessageData{ Sender = "Barnaby Hunter", Message = "Still waiting...", MessageDelivered = "11.10", BackgroundColor = Color.FromArgb("#FECAD1"), TextColor = Color.FromArgb("#FD5064"), StatusColor = Color.FromArgb("#60C858") },
            new MessageData{ Sender = "Peter Bence", Message = "Can you come by my desk?", MessageDelivered = "14.09", BackgroundColor = Color.FromArgb("#FECAD1"), TextColor = Color.FromArgb("#FD5064"), StatusColor = Color.FromArgb("#F85446") },
            new MessageData{ Sender = "Peter Bence", Message = "Happy Holidays! See you next week.", MessageDelivered = "5.08", BackgroundColor = Color.FromArgb("#CCE7CB"), TextColor = Color.FromArgb("#56AF51"), StatusColor = Color.FromArgb("#60C858") },
            new MessageData{ Sender = "Howard Pittman", Message = "You: I will discuss the case with the manager.", MessageDelivered = "20.06", BackgroundColor = Color.FromArgb("#D3F2F3"), TextColor = Color.FromArgb("#55D3DE"), StatusColor = Color.FromArgb("#F85446") },
            new MessageData{ Sender = "Joel Walsh", Message = "Thank you for your help!", MessageDelivered = "10.06", BackgroundColor = Color.FromArgb("#FECAD1"), TextColor = Color.FromArgb("#FD5064"), StatusColor = Color.FromArgb("#F85446") },
            new MessageData{ Sender = "Matias Santos", Message = "You: Coffee break?", MessageDelivered = "13.05", BackgroundColor = Color.FromArgb("#FECAD1"), TextColor = Color.FromArgb("#FD5064"), StatusColor = Color.FromArgb("#F85446") },
            new MessageData{ Sender = "Xavi Vasquez", Message = "I will be out of the office.", MessageDelivered = "3.02", BackgroundColor = Color.FromArgb("#FECAD1"), TextColor = Color.FromArgb("#FD5064"), StatusColor = Color.FromArgb("#F85446") },
        };
    }

    public ObservableCollection<MessageData> Messages { get; set; }
}
