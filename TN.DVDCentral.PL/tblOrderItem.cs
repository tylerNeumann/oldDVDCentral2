﻿using System;
using System.Collections.Generic;

namespace TN.DVDCentral.PL;

public partial class tblOrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int Quantity { get; set; }

    public int MovieId { get; set; }

    public double Cost { get; set; }
}
