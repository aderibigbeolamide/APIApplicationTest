﻿using System;

namespace APIApplication.Contracts
{
    public interface ISoftDelete
    {
        public DateTime DeletedOn { get; set; }
        public int DeletedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
}
