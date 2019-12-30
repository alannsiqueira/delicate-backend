﻿namespace Delicate.Application.Response
{
    public class Notification
    {
        public string Property { get;  }

        public string Message { get;  }

        public Notification(string property, string message)
        {
            Property = property;
            Message = message;
        }
    }
}