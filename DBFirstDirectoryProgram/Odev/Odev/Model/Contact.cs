using System;
using System.Collections.Generic;

namespace Odev.Model;

public partial class Contact
{
    public int? ContactId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }
}
