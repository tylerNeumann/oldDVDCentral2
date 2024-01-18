﻿using System;
using System.Collections.Generic;

namespace TN.DVDCentral.PL2.Entities;

public class tblOrderItem
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public int Quantity { get; set; }

    public Guid MovieId { get; set; }

    public double Cost { get; set; }
}
