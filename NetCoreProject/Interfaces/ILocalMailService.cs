﻿namespace NetCoreProject.Interfaces
{
    public interface ILocalMailService
    {
        void Send(string subject, string message);
    }
}
