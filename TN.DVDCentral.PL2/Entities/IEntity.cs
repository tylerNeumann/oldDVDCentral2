﻿namespace TN.DVDCentral.PL2.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        string SortField {  get;  }
    }
}
