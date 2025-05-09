﻿using Microsoft.EntityFrameworkCore;

namespace ComputergyAPI.Entites
{
    public abstract class MainEntity
    {
        
        public int Id { get; set; } //Primary Key - Identity
        public string CreatedBy { get; set; } // nvarchar(max) not allowed to be null
        public string? UpdatedBy { get; set; } //nvarhcar(max) nullable
        public DateTime CreationDate { get; set; } //DateTime not null
        public DateTime? UpdatedDate { get; set; }//DateTime nullable
        public bool IsActive { get; set; } = true; //bit not null  with default value of true 
    }
}
