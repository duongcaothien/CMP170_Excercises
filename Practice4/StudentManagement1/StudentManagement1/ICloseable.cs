using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement1
{
    public interface ICloseable
    {
        event EventHandler CloseRequest;
    }
}
